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

        public HomeViewModel(Configuration configuration, UserService userService)
        {
            m_Configuration = configuration;
            m_UserService = userService;

            Tours = m_UserService.GetToursOfUser(m_Configuration.User.Id).Result.ToList();
            if(Tours.Count == 0 ) 
            {
                emptyTours = true;
            }
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
                { "passTour",  tour}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task ShowNotification()
        {
            await Shell.Current.GoToAsync("Notifications");
        }        
    }
}
