using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    public partial class CreateTourViewModel : ObservableObject
    {
        //private readonly TourService m_TourService;
       // private readonly IDialogService DialogService;
       // private readonly Configuration m_Configuration;
        public ObservableCollection<TourDTO> m_vTour { get; set; } = new ObservableCollection<TourDTO> ();
        public ObservableCollection<string> m_vCurrent { get; set; } = new ObservableCollection<string> ();
        
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
        string numberPhoneToBlik;

        [ObservableProperty]
        string targetCountry;

        [ObservableProperty]
        string title;


        public CreateTourViewModel(/*TourService tourService, IDialogService dialogService, Configuration configuration*/)
        {
           // m_TourService = new TourService(); // tourService;
           // DialogService = newdialogService;
           // m_Configuration = configuration;

            DateTerm = "11.05.2023 - 25.05.2023";
            ParticipantMax = 13;
            m_vCurrent.Add("PL");
            m_vCurrent.Add("EURO");
            m_vCurrent.Add("KUN");
            current = m_vCurrent[0];
            budgetSize = 5213;
            accountNumber = "1230 5123 0000 0000 1234 5123";
            blikAccept = true;
            numberPhoneToBlik = "(+48) 530 220 240";
            
        }

        
        [RelayCommand]
        async Task SetTourDateRange()
        {
            

        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
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
