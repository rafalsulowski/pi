using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels.Tour
{
    public partial class TourViewModel : ObservableObject, IQueryAttributable
    {
        private readonly TourService m_TourService;

        [ObservableProperty]
        int tourId;

        [ObservableProperty]
        TourDTO tour;

        public TourViewModel(TourService tourService)
        {
            m_TourService = tourService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            Tour = m_TourService.GetTourById(TourId).Result;

            if(Tour is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało pobrać się informacji o wycieczce, sprawdź swoje połączenie internetowe", "Ok");
                var navigationParameter = new Dictionary<string, object> { };
                await Shell.Current.GoToAsync("//Home", navigationParameter);
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Reload", false }
            };
            await Shell.Current.GoToAsync("//Home", navigationParameter);
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
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"/Chat", navigationParameter);
        }

        [RelayCommand]
        async Task GoParticipants()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"/Participants", navigationParameter);
        }

        [RelayCommand]
        async Task GoShares()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"/Shares", navigationParameter);
        }

        [RelayCommand]
        async Task GoSchedule()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"/ScheduleList", navigationParameter);
        }

    }
}
