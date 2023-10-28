using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    [QueryProperty("passTour", "Tour")]
    public partial class FriendsViewModel : ObservableObject, IQueryAttributable
    {
        TourDTO Tour;
        private ObservableCollection<ExtendFriendDTO> Friends;

        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private readonly UserService m_UserService;

        [ObservableProperty]
        string searchExpression;

        [ObservableProperty]
        ObservableCollection<ExtendFriendDTO> friendsRef;

        public FriendsViewModel(Configuration configuration, TourService tourService, UserService userService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            m_UserService = userService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tour = (TourDTO)query["passTour"];

            if (Tour == null)
            {
                Shell.Current.CurrentPage.DisplayAlert("Awaria", "Niespodziewany brak danych wycieczki!", "Ok :(");
                return;
            }
            else
            {
                Friends = m_UserService.GetFriends(m_Configuration.User.Id).Result.ToObservableCollection();
                FriendsRef = Friends;
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
        async Task Add(UserDTO user)
        {
            var res = await Shell.Current.CurrentPage.DisplayAlert("Dodawanie uczestnika", $"Czy potwierdzasz dodanie {user.FullAddress} do wyajzdu", "Ok", "Anuluj");

            if(res)
            {
                var res2 = await m_TourService.AddParticipant(Tour.Id, user.Id);
                if (res2)
                {
                    var confirmCopyToast = Toast.Make("Dodano nowego uczestnika", ToastDuration.Short, 14);
                    await confirmCopyToast.Show();
                }
                else
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się dodać nowego uczestnika do wyjazdu", "Ok :(");
            }
        }

        [RelayCommand]
        async Task OpenCalendar()
        {
            await Shell.Current.GoToAsync("Calendar");
        }

    }
}
