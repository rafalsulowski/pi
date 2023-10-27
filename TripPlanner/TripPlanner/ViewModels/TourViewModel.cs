using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    [QueryProperty("passTour", "Tour")]
    public partial class TourViewModel : ObservableObject, IQueryAttributable
    {

        private readonly TourService m_TourService;
        private readonly Configuration m_Configuration;


        [ObservableProperty]
        int tourId;

        [ObservableProperty]
        TourDTO tour;

        public TourViewModel(TourService tourService, Configuration configuration)
        {
            m_TourService = tourService;
            m_Configuration = configuration;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            Tour = m_TourService.GetTourById(TourId).Result;
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
            TourDTO NewTour = await m_TourService.GetTourWithMessages(Tour.Id);

            if(NewTour == null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać wiadomości!", "Ok :(");
                return;
            }

            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  NewTour}
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

    }
}
