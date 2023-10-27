
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
    public partial class AddParticipantsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private readonly UserService m_UserService;
        private ObservableCollection<ExtendParticipantDTO> FriendsRef;
                
        [ObservableProperty]
        int tourId;

        [ObservableProperty]
        bool refresh;

        [ObservableProperty]
        ObservableCollection<ExtendParticipantDTO> friends;

        public AddParticipantsViewModel(Configuration configuration, TourService tourService, UserService userService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            m_UserService = userService;
            Friends = new ObservableCollection<ExtendParticipantDTO>();
            FriendsRef = new ObservableCollection<ExtendParticipantDTO>();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            LoadData();
        }   

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"/Tour/Participants", navigationParameter);
        }

        [RelayCommand]
        async Task Add()
        {
            //TODO
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
            var value = m_UserService.GetFriends(m_Configuration.User.Id).Result;

            if (value is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy znajomych", "Ok");
            }
            else
            {
                Friends = value.ToObservableCollection();
                FriendsRef = value.ToObservableCollection();
            }
        }
    }
}
