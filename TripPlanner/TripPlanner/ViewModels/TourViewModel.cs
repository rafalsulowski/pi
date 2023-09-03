using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.ViewModels
{
    [QueryProperty("passTour", "Tour")]
    public partial class TourViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        TourDTO tour;

        public TourViewModel()
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tour = (TourDTO)query["passTour"];
        }


        [RelayCommand]
        async Task OpenHomePage()
        {
            await Shell.Current.GoToAsync("Home");
        }

        [RelayCommand]
        async Task ShowFriends()
        {
            await Shell.Current.GoToAsync("Friends");
        }

        [RelayCommand]
        async Task ShowNotification()
        {
            await Shell.Current.GoToAsync("Notifications");
        }

        [RelayCommand]
        async Task ShowProfile()
        {
            await Shell.Current.GoToAsync("Profile");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
