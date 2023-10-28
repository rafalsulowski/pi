
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models.UserModels;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{

    [QueryProperty("passTourId", "TourId")]
    public partial class AddParticipantsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private readonly UserService m_UserService;
        private ObservableCollection<ExtendFriendDTO> FriendsRef;
        private int TourId;

        [ObservableProperty]
        bool refresh;

        [ObservableProperty]
        ObservableCollection<ExtendFriendDTO> friends;

        public AddParticipantsViewModel(Configuration configuration, TourService tourService, UserService userService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            m_UserService = userService;
            Friends = new ObservableCollection<ExtendFriendDTO>();
            FriendsRef = new ObservableCollection<ExtendFriendDTO>();
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
        async Task Add(ExtendFriendDTO friend)
        {
            if(friend.IsParticipant)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik jest już uczestnikiem tej wycieczki", "Ok");
            }
            else
            {
                var result = await Shell.Current.CurrentPage.DisplayAlert("Uwaga", $"Czy na pewno chcesz dodać użytkownika {friend.FullName} do wycieczki?", "Dodaj", "Anuluj");

                if(result)
                {
                    var response = await m_TourService.AddParticipant(TourId, friend.UserId);
                    if(response)
                    {
                        await RefreshViewAfterAdd();
                        var confirmCopyToast = Toast.Make("Dodano do wyjazdu", ToastDuration.Short, 14);
                        await confirmCopyToast.Show();
                    }
                    else
                    {
                        await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie udało się dodać znajomego do wyjazdu", "Ok");
                    }
                }
            }
        }


        [RelayCommand]
        public async Task ParticipantSearching(string query)
        {
            if (string.IsNullOrEmpty(query))
                Friends = FriendsRef;
            else
                Friends = FriendsRef.Where(i => i.FullName.StartsWith(query, StringComparison.OrdinalIgnoreCase))?.ToObservableCollection();
        }

        [RelayCommand]
        async Task RefreshView()
        {
            Refresh = true;
            LoadData();

            var confirmCopyToast = Toast.Make("Odświerzono listę znajomych", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
            Refresh = false;
        }

        async Task RefreshViewAfterAdd()
        {
            LoadData();
        }

        private async void LoadData()
        {
            var value = m_UserService.GetFriendsBasedOnTour(m_Configuration.User.Id, TourId).Result;

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
