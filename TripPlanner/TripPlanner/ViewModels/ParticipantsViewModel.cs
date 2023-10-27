
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ParticipantsListViews;

namespace TripPlanner.ViewModels
{

    [QueryProperty("passTourId", "TourId")]
    public partial class ParticipantsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private ObservableCollection<ExtendParticipantDTO> ParticipantsRef;

        [ObservableProperty]
        TourDTO tour;
        
        [ObservableProperty]
        int tourId;

        [ObservableProperty]
        bool refresh;

        [ObservableProperty]
        ObservableCollection<ExtendParticipantDTO> participants;

        public ParticipantsViewModel(Configuration configuration, TourService tourService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            Participants = new ObservableCollection<ExtendParticipantDTO>();
            ParticipantsRef = new ObservableCollection<ExtendParticipantDTO>();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            Tour = m_TourService.GetTourById(TourId).Result;
            LoadData();
        }   

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  Tour.Id}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task Add()
        {
            var result = await Shell.Current.CurrentPage.ShowPopupAsync(new AddParticipantPopup(Tour));
        }

        [RelayCommand]
        async Task Export()
        {
        }

        [RelayCommand]
        public async Task ParticipantSearching(string query)
        {
            if (string.IsNullOrEmpty(query))
                Participants = ParticipantsRef;
            else
                Participants = ParticipantsRef.Where(i => i.FullName.StartsWith(query, StringComparison.OrdinalIgnoreCase))?.ToObservableCollection();
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

        [RelayCommand]
        public async Task CopyToClipboard()
        {
            await Clipboard.Default.SetTextAsync(Tour.InviteLink);

            var confirmCopyToast = Toast.Make("Skopiowano do schowka", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
        }

        [RelayCommand]
        async Task RefreshView()
        {
            Refresh = true;
            LoadData();

            var confirmCopyToast = Toast.Make("Odświerzono listę uczestników", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
            Refresh = false;
        }

        private async void LoadData()
        {
            var value = m_TourService.GetTourExtendParticipant(Tour.Id).Result;

            if (value is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy uczestników wyjazdu", "Ok");
            }
            else
            {
                Participants = value.ToObservableCollection();
                ParticipantsRef = value.ToObservableCollection();
            }
        }
    }
}
