using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.Metrics;
using TripPlanner.Controls.QuestionnaireControls;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.DTO.MessageDTOs.QuestionnaireDTOs;
using TripPlanner.Models.Models.UserModels;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels.Chat
{
    public interface IHasCollectionViewModel
    {
        IHasCollectionView View { get; set; }
    }
    public interface IHasCollectionView
    {
        CollectionView CollectionView { get; }
    }

    public partial class ChatViewModel : ObservableObject, IQueryAttributable, IHasCollectionViewModel
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private readonly ChatService m_ChatService;
        private HubConnection m_Connection;
        private int TourId;

        public IHasCollectionView View { get; set; }


        [ObservableProperty]
        ObservableCollection<MessageDTO> messages;

        [ObservableProperty]
        string message;

        public ChatViewModel(Configuration configuration, TourService tourService, ChatService chatService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            m_ChatService = chatService;
            Messages = new ObservableCollection<MessageDTO>();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            await Connect();
        }

        async Task Connect()
        {
            try
            {
                m_Connection = new HubConnectionBuilder()
                .WithUrl(m_Configuration.WssUrl)
                .Build();

                m_Connection.On<string>("TextMessageReceived", (message) =>
                {
                    TextMessageDTO msg = JsonConvert.DeserializeObject<TextMessageDTO>(message);
                    if (msg != null)
                    {
                        Messages.Add(msg);
                    }
                });

                m_Connection.On<string>("NoticeMessageReceived", (message) =>
                {
                    NoticeMessageDTO msg = JsonConvert.DeserializeObject<NoticeMessageDTO>(message);
                    if (msg != null)
                    {
                        Messages.Add(msg);
                    }
                });

                m_Connection.On<string>("QuestionnaireReceived", (message) =>
                {
                    QuestionnaireDTO msg = JsonConvert.DeserializeObject<QuestionnaireDTO>(message);
                    if (msg != null)
                    {
                        Messages.Add(msg);
                    }
                });

                m_Connection.On<string>("QuestionnaireVoteReceived", (message) =>
                {
                    QuestionnaireDTO msg = JsonConvert.DeserializeObject<QuestionnaireDTO>(message);
                    var elem = Messages.FirstOrDefault(u=> u.Id == msg.Id);
                    int index = Messages.IndexOf(elem);
                    if (msg != null && index != -1)
                    {
                        Messages.RemoveAt(index);
                        Messages.Insert(index, msg);
                        View.CollectionView.ScrollTo(elem);
                    }
                });

                m_Connection.On<string>("SetConnection", (message) =>
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    List<MessageDTO> msgs = JsonConvert.DeserializeObject<List<MessageDTO>>(message, settings);
                    Messages = msgs.ToObservableCollection();
                    //if(Messages.Any())
                    //    View.CollectionView.ScrollTo(Messages.Last(), ScrollToPosition.End, animate: false);
                });

                await m_Connection.StartAsync();
                await m_Connection.InvokeCoreAsync("SetConnection", args: new[] { TourId.ToString() });
            }
            catch (HubException ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie udało wykonać operacji", "Ok");
            }
            catch(Exception)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            await m_Connection.InvokeCoreAsync("LeaveGroup", args: new[] { TourId.ToString() });

            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task SendTextMessage()
        {
            try
            {
                //walidacja treści wiadomości pod wzgledem prób hackowania
                Message = Message.TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(Message))
                    return;

                CreateTextMessageDTO msg = new CreateTextMessageDTO
                {
                    Content = Message,
                    UserId = m_Configuration.User.Id,
                    TourId = TourId
                };

                string json = JsonConvert.SerializeObject(msg);
                await m_Connection.InvokeCoreAsync("SendTextMessage", args: new[] { json });
                Message = String.Empty;
            }
            catch (HubException ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się oddać głosu", "Ok");
            }
            catch (Exception)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
            }
        }

        [RelayCommand]
        async Task SendNoticeMessage()
        {
            try
            {
                //walidacja treści wiadomości pod wzgledem prób hackowania
                Message = Message.TrimStart().TrimEnd();

                if (string.IsNullOrEmpty(Message))
                    return;

                CreateNoticeMessageDTO msg = new CreateNoticeMessageDTO
                {
                    Content = Message,
                    UserId = m_Configuration.User.Id,
                    TourId = TourId
                };

                string json = JsonConvert.SerializeObject(msg);
                await m_Connection.InvokeCoreAsync("SendNoticeMessage", args: new[] { json });
                Message = String.Empty;
            }
            catch (HubException ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"{ex.Message}", "Ok");
            }
            catch (Exception)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
            }
        }

        [RelayCommand]
        async Task ShowMoreChatAction()
        {
            await Shell.Current.CurrentPage.ShowPopupAsync(new ChatAdditionalMenuPopup(m_TourService, TourId));
        }


        [RelayCommand]
        async Task Vote(AnswerGDTO answer)
        {
            try
            {
                CreateQuestionnaireVoteDTO msg = new CreateQuestionnaireVoteDTO
                {
                    QuestionnaireId = answer.QuestionnaireId,
                    AnswerId = answer.Id,
                    TourId = TourId,
                    UserId = m_Configuration.User.Id
                };

                string json = JsonConvert.SerializeObject(msg);
                await m_Connection.InvokeCoreAsync("SendQuestionnaireVote", args: new[] { json });
                var confirmCopyToast = Toast.Make($"Oddano swój głos", ToastDuration.Long, 14);
                await confirmCopyToast.Show();
            }
            catch (HubException ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"{ex.Message}", "Ok");
            }
            catch (Exception)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
            }
        }

        [RelayCommand]
        async Task ShowVoters(AnswerGDTO answer)
        {
            var res = m_ChatService.GetAnswerVoters(answer.Id, TourId);
            await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups($"Zagłosowali na \"{answer.Answer}\"", res.Result));
        }
    }
}
