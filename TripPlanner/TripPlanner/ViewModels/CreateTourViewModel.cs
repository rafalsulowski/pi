using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Models.Models.MessageModels;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    public partial class CreateTourViewModel : ObservableObject
    {
        private readonly TourService m_TourService;
        private readonly Configuration m_Configuration;
        public ObservableCollection<TourDTO> m_vTour { get; set; } = new ObservableCollection<TourDTO>();

        [ObservableProperty]
        DateTime startDate;

        [ObservableProperty]
        DateTime stopDate;

        [ObservableProperty]
        int participantMax;

        [ObservableProperty]
        string targetCountry;

        [ObservableProperty]
        string targetRegion;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string description;

        public CreateTourViewModel(TourService tourService, Configuration configuration)
        {
            m_TourService = tourService;
            m_Configuration = configuration;

            startDate = DateTime.Now;
            stopDate = DateTime.Now;

            //startDate = new DateTime(2023,12,29);
            //stopDate = new DateTime(2024,1,4);
            //ParticipantMax = 13;
            //title = "Wyjazd na narty 2024";
            //description = "Pierwszy wyajzd na słowację";
            //targetCountry = "Słowacja";
            //targetRegion = "Chopok";
        }


        [RelayCommand]
        async Task SetTourDateRange()
        {
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("//Home");
        }

        [RelayCommand]
        async Task GoNext()
        {
            //walidacja i utworzenie wycieczki

            CreateTourDTO tour = new CreateTourDTO
            {
                Title = Title,
                Description = Description,
                MaxParticipant = ParticipantMax,
                TargetCountry = TargetCountry,
                TargetRegion = TargetRegion,
                UserId = m_Configuration.User.Id,
                CreateDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0),
                StartDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 12, 0, 0),
                EndDate = new DateTime(StopDate.Year, StopDate.Month, StopDate.Day, 12, 0, 0),
            };

            RepositoryResponse<int> resp = m_TourService.CreateTour(tour).Result;
            
            if(!resp.Success)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Błąd podczas tworzenia wyiceczki! Wiadomość od serwera: {resp.Message}", "Ok :(");
                return;
            }

            TourDTO newTour = m_TourService.GetTourById(resp.Data).Result;

            if (resp is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Błąd podczas pobrania nowo utowrzonej wycieczki! Wycieczka zostałą utowrzony jendak nie została poprawnie pobrana z powrotem do aplikacji. Spróbuj wejść w wycieczkę z widoku głównego!", "Ok :(");
                return;
            }

            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  newTour}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

    }
}
