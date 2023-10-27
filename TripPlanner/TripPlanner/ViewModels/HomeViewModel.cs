using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly UserService m_UserService;
        private readonly Configuration m_Configuration;

        [ObservableProperty]
        public List<TourDTO> tours;

        [ObservableProperty]
        bool emptyTours;
        
        [ObservableProperty]
        bool refresh;


        public HomeViewModel(Configuration configuration, UserService userService)
        {
            m_Configuration = configuration;
            m_UserService = userService;
            Refresh = false;
            EmptyTours = false;
            LoadData();
        }
        
        [RelayCommand]
        async Task OpenCalendar()
        {
            await Shell.Current.GoToAsync("Calendar");
        }

        [RelayCommand]
        async Task CreateTrip()
        {
            await Shell.Current.GoToAsync("CreateTour");
        }

        [RelayCommand]
        async Task ShowTour(TourDTO tour)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  tour.Id}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task ShowNotification()
        {
            await Shell.Current.GoToAsync("Notifications");
        }

        [RelayCommand]
        async Task RefreshView()
        {
            Refresh = true;
            LoadData();

            var confirmCopyToast = Toast.Make("Odświerzono listę wycieczek", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
            Refresh = false;
        }

        private void LoadData()
        {
            Tours = m_UserService.GetToursOfUser(m_Configuration.User.Id).Result.ToList();
            if (Tours.Count == 0)
            {
                EmptyTours = true;
            }
            else
                EmptyTours = false;
        }
    }
}
