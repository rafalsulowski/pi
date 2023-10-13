using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("//Home");
        }

        [RelayCommand]
        async Task GoSettings()
        {
            await Shell.Current.GoToAsync("Settings");
        }

        [RelayCommand]
        async Task GoChat()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"/Chat", navigationParameter);
        }

        [RelayCommand]
        async Task GoParticipants()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"/Participants", navigationParameter);
        }

    }
}
