using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Controls.QuestionnaireControls;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels
{
    [QueryProperty("passTour", "Tour")]
    public partial class ChatViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private readonly ChatService m_ChatService;
        private readonly QuestionnaireService m_QuestionnaireService;

        [ObservableProperty]
        TourDTO tour;

        [ObservableProperty]
        ChatDTO chat;

        [ObservableProperty]
        ObservableCollection<MessageDTO> messages;

        [ObservableProperty]
        bool promptLabel;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string message;

        [ObservableProperty]
        int? userId;

        public ChatViewModel(Configuration configuration, TourService tourService, ChatService chatService, QuestionnaireService questionnaireService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            m_ChatService = chatService;
            m_QuestionnaireService = questionnaireService;

            IsRefreshing = false;
            UserId = m_Configuration.User.Id;
            Messages = new ObservableCollection<MessageDTO>();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tour = (TourDTO)query["passTour"];

            if (Tour != null)
            {
                //pobrac z api dane czatu czyli wiadomosci i ankiety

                Chat = Tour.Chat;
                Chat.Messages = Chat.Messages.Reverse().ToList();
                if (Chat.Messages.Count >= m_Configuration.AddChatMessagesWhileReload)
                {
                    Messages = Chat.Messages.Take(m_Configuration.AddChatMessagesWhileReload).ToObservableCollection();
                }
                else
                {
                    Messages = Chat.Messages.ToObservableCollection();
                }

            }
            else
            {
            }

            PromptLabel = Messages.Count > 0 ? false : true;
        }

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task SendMessage()
        {
            if (Message != null && Message != "")
            {
                //wyslac do api

                Messages.Add(new TextMessageDTO
                {
                    Content = Message,
                    UserId = m_Configuration.User.Id,
                    ChatId = Chat.Id,
                    Id = -1,
                    LikesCount = 0,
                    Date = DateTime.Now
                });
            }
        }

        [RelayCommand]
        async Task LoadMoreMessages()
        {
            IsRefreshing = true;
            for (int i = 0; i < m_Configuration.AddChatMessagesWhileReload; i++)
            {
                if (Messages.Count == Chat.Messages.Count)
                {
                    //pobrac z api wiecej wiadomosci,
                    //dac wtedy activitiindicator zeby sie krecil
                    //potem break
                    break;
                }

                Messages.Add(Chat.Messages.ElementAt(Messages.Count));
            }

            Thread.Sleep(2000);
            IsRefreshing = false;
        }

        [RelayCommand]
        async Task ShowMoreChatAction()
        {
            await Shell.Current.CurrentPage.ShowPopupAsync(new ChatAdditionalMenuPopup(m_TourService, Tour, Chat.Id));
        }



        [RelayCommand]
        async Task Vote(AnswerGDTO answer)
        {
            var res = m_QuestionnaireService.VoteForAnswer(m_Configuration.User.Id, answer.Id);

            if (res.Result == false)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się oddać głosu!", "Ok");
            }
        }

        [RelayCommand]
        async Task ShowVoters(AnswerGDTO answer)
        {
            var res = m_QuestionnaireService.GetAnswerVoters(answer.Id);

            if (res.Result != null)
            {
                await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups($"Zagłosowali na \"{answer.Answer}\"", res.Result));
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy osób czatu!", "Ok");
        }
    }
    }
