using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        private readonly QuestionnaireService m_QuestionnaireService;
        private int TourId;

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

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            //await m_ChatService.Connect();
           // await LoadData();
        }

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task SendMessage()
        {
            //if (Message != null && Message != "")
            //{
            //    int id = await m_ChatService.SendMessage(Message);

            //    Messages.Add(new TextMessageDTO
            //    {
            //        Content = Message,
            //        UserId = m_Configuration.User.Id,
            //        Id = id,
            //        Date = DateTime.Now
            //    });
            //}
        }
        
        [RelayCommand]
        async Task ShowMoreChatAction()
        {
            await Shell.Current.CurrentPage.ShowPopupAsync(new ChatAdditionalMenuPopup(m_TourService, Tour));
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

        async Task LoadData()
        {
            //Tour = await m_TourService.GetTourWithMessages(TourId);
            //if(Tour is null)
            //{
            //    await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać wiadomości", "Ok");
            //    return;
            //}
            //Messages = Tour.Messages.Reverse().ToObservableCollection();
        }
    }
}
