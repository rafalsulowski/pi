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
using TripPlanner.Controls.QuestionnaireControls;
using TripPlanner.Models.DTO.MessageDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels
{
    public partial class ChatViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private readonly ChatService m_ChatService;
        private HubConnection m_Connection;
        private int TourId;

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

                m_Connection.On<string>("MessageReceived", (message) =>
                {
                    TextMessageDTO msg = JsonConvert.DeserializeObject<TextMessageDTO>(message);
                    if (msg != null)
                    {
                        Messages.Add(msg);
                    }
                });

                m_Connection.On<string>("SetConnection", (message) =>
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    List<MessageDTO> msgs = JsonConvert.DeserializeObject<List<MessageDTO>>(message, settings);
                    Messages = msgs.ToObservableCollection();
                });

                await m_Connection.StartAsync();

                //wyslanie wiadomosci do api ze zaczynamy korzystac z czatu
                await m_Connection.InvokeCoreAsync("SetConnection", args: new[] { TourId.ToString() });
            }
            catch (HubException ex)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"{ex.Message}", "Ok");
            }
            catch(Exception)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nieznany błąd", "Ok");
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            //wyslanie wiadomosci do api ze konczymy korzystac z czatu
            await m_Connection.InvokeCoreAsync("LeaveGroup", args: new[] { TourId.ToString() });

            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task SendMessage()
        {
            try
            {
                //walidacja treści wiadomości pod wzgledem prób hackowania
                Message = Message.TrimStart().TrimStart();

                if (string.IsNullOrEmpty(Message))
                    return;

                TextMessageDTO msg = new TextMessageDTO
                {
                    Content = Message,
                    Date = DateTime.Now,
                    UserId = m_Configuration.User.Id,
                    TourId = TourId
                };

                string json = JsonConvert.SerializeObject(msg);
                await m_Connection.InvokeCoreAsync("SendTextMessage", args: new[] { json });
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

        //[RelayCommand]
        //async Task Vote(AnswerGDTO answer)
        //{
        //    var res = await m_ChatService.VoteForAnswer(m_Configuration.User.Id, answer.Id);
        //    if (res.Success)
        //    {
        //        //jakaś zmiana w interfejsie uzytkownika, odświerzenie ankiety
        //        var confirmCopyToast = Toast.Make($"Oddano swój głos", ToastDuration.Long, 14);
        //        await confirmCopyToast.Show();
        //    }
        //    else
        //        await Shell.Current.CurrentPage.DisplayAlert("Błąd", res.Message, "Ok");

        //}

        //[RelayCommand]
        //async Task ShowVoters(AnswerGDTO answer)
        //{
        //    var res = m_ChatService.GetAnswerVoters(answer.Id);
        //    await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups($"Zagłosowali na \"{answer.Answer}\"", res.Result));
        //}
    }
}
