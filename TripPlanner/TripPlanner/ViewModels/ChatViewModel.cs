using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.ObjectModel;
using TripPlanner.Controls.QuestionnaireControls;
using TripPlanner.Models.DTO.MessageDTOs;
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
        ObservableCollection<MessageDTO> messages;

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string message;


        public ChatViewModel(Configuration configuration, TourService tourService, ChatService chatService, QuestionnaireService questionnaireService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            m_ChatService = chatService;
            m_QuestionnaireService = questionnaireService;

            IsRefreshing = false;
            Messages = new ObservableCollection<MessageDTO>();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tour = (TourDTO)query["passTour"];
            Messages = Tour.Messages.Reverse().ToObservableCollection();
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
            if (hubConnection is not null)
            {
                await hubConnection.SendAsync("SendMessage", "test1", "test2");
            }


            //if (Message != null && Message != "")
            //{
            //    //wyslac do api

            //    Messages.Add(new TextMessageDTO
            //    {
            //        Content = Message,
            //        UserId = m_Configuration.User.Id,
            //        ChatId = Chat.Id,
            //        Id = -1,
            //        Date = DateTime.Now
            //    });
            //}
        }

        [RelayCommand]
        async Task LoadMoreMessages()
        {
            IsRefreshing = true;
            for (int i = 0; i < m_Configuration.AddChatMessagesWhileReload; i++)
            {
                if (Messages.Count == Tour.Messages.Count)
                {
                    //pobrac z api wiecej wiadomosci,
                    //dac wtedy activitiindicator zeby sie krecil
                    //potem break
                    break;
                }

                Messages.Add(Tour.Messages.ElementAt(Messages.Count));
            }
            IsRefreshing = false;
        }

        private HubConnection hubConnection;
        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;

        [RelayCommand]
        async Task ShowMoreChatAction()
        {
            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl("wss://localhost:7035/chat")
                .WithAutomaticReconnect()
                .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var formattedMessage = $"cos tam";
                Messages.Add(new TextMessageDTO { Content = $"{user} {message}" });
            });

            await hubConnection.StartAsync();

            //await Shell.Current.CurrentPage.ShowPopupAsync(new ChatAdditionalMenuPopup(m_TourService, Tour, Chat.Id));
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
                //TODO
                //await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups($"Zagłosowali na \"{answer.Answer}\"", res.Result));
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy osób czatu!", "Ok");
        }
    }
    }
