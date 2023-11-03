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

            //dane testowe
            startDate = new DateTime(2023, 12, 29);
            stopDate = new DateTime(2024, 1, 4);
            ParticipantMax = 13;
            title = "Wyjazd na narty 2024";
            description = "Pierwszy wyajzd na słowację";
            targetCountry = "Słowacja";
            targetRegion = "Chopok";
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("//Home");
        }

        [RelayCommand]
        async Task GoNext()
        {
            //walidacja
            if(string.IsNullOrEmpty(Title))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Tytul wycieczki nie może być pusty", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(TargetCountry))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Musisz określić docelowy kraj wyczieczki", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(TargetRegion))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Musisz określić docelowe miejsce wyczieczki", "Ok");
                return;
            }
            if (ParticipantMax > 1000 || ParticipantMax < 0)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Liczba uczestników musi być z zakresu (0, 1000)", "Ok");
                return;
            }
            if (StopDate < DateTime.Now || StartDate < DateTime.Now)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Data zakończenia lub rozpoczęcia wycieczki już mineła", "Ok");
                return;
            }
            if (StopDate < StartDate)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Data zakończenia wycieczki nie może być przed datą jej rozpoczecia", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Title))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Niepoprawne dane", $"Tytul wycieczki nie może być pusty", "Ok");
                return;
            }

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
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"{resp.Message}", "Ok");
                return;
            }

            TourDTO newTour = m_TourService.GetTourById(resp.Data).Result;

            if (resp is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Błąd podczas pobrania nowo utowrzonej wycieczki! Wycieczka została utowrzona jendak nie została poprawnie załadowana do aplikacji. Odświerz stronę główną i spróbuj wejść w wycieczkę!", "Ok");
                return;
            }

            await Shell.Current.CurrentPage.DisplayAlert("Powodzednie", $"Utworzono wyjazd", "Ok");
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  newTour.Id}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

    }
}
