
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ParticipantsListViews;

namespace TripPlanner.ViewModels
{

    [QueryProperty("passTour", "Tour")]
    public partial class ParticipantsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;

        [ObservableProperty]
        TourDTO tour;

        [ObservableProperty]
        string searchExpression;

        [ObservableProperty]
        ObservableCollection<ExtendParticipantDTO> participants;

        [ObservableProperty]
        ObservableCollection<ExtendParticipantDTO> participantsRef;

        public ParticipantsViewModel(Configuration configuration, TourService tourService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;

            Participants = new ObservableCollection<ExtendParticipantDTO>();
            ParticipantsRef = new ObservableCollection<ExtendParticipantDTO>();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tour = (TourDTO)query["passTour"];

            if(Tour == null)
            {
                Shell.Current.CurrentPage.DisplayAlert("Awaria", "Niespodziewany brak danych o wyjeździe!", "Ok :(");
                return;
            }
            else
            {
                Participants = m_TourService.GetParticipants(Tour.Id).Result;
                ParticipantsRef = Participants;
            }
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
        async Task Add()
        {
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(new AddParticipantPopup(Tour, Tour.InviteLink));
        }

        [RelayCommand]
        async Task Export()
        {
        }

        [RelayCommand]
        public async Task ParticipantSearching()
        {
            ParticipantsRef = Participants.Where(i => i.FullName.Contains(SearchExpression)).ToObservableCollection();
        }

        [RelayCommand]
        public async Task GoToFriendsList()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"AddParticipantFromFriends", navigationParameter);
        }

        [RelayCommand] //zrobic interface viewmodela z ta funkcja do wykorzystywania
        public async Task CopyToClipboard()
        {
            await Clipboard.Default.SetTextAsync(Tour.InviteLink);

            var confirmCopyToast = Toast.Make("Skopiowano do schowka", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
        }


    }
}
