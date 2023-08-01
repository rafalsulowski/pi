using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    public partial class CreateTourViewModel : ObservableObject
    {
        private readonly TourService m_TourService;
        private readonly IDialogService DialogService;
        private readonly Configuration m_Configuration;
        public ObservableCollection<TourDTO> m_vTour { get; set; } = new ObservableCollection<TourDTO> ();
        
        [ObservableProperty]
        string dateTerm;

        [ObservableProperty]
        int participantMax;

        [ObservableProperty]
        decimal budgetSize;

        [ObservableProperty]
        string current;

        [ObservableProperty]
        string accountNumber;

        [ObservableProperty]
        bool blikAccept;

        [ObservableProperty]
        string numberPhoneToBLik;

        [ObservableProperty]
        string targetCountry;

        [ObservableProperty]
        string title;


        public CreateTourViewModel(TourService tourService, IDialogService dialogService, Configuration configuration)
        {
            m_TourService = tourService;
            DialogService = dialogService;
            m_Configuration = configuration;

            DateTerm = "11.05.2023 - 25.05.2023";
            ParticipantMax = 13;
        }
        
        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("//");
        }

        [RelayCommand]
        async Task GoNext()
        {
            await Shell.Current.GoToAsync("CreateTrip2");
        }

        [RelayCommand]
        async Task ShowInfoAboutBudget()
        {
            //
        }
    }
}
