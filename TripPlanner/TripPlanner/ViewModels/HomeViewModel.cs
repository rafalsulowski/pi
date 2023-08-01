using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TourService m_TourService;
        private readonly IDialogService DialogService;
        private readonly Configuration m_Configuration;
        public ObservableCollection<TourDTO> m_vTour { get; set; } = new ObservableCollection<TourDTO> ();
        public TourDTO m_NearestTour { get; set; }
        public int m_fAngle { get; set; } = 90;
        public string m_startNameDayOfWeek { get; set; }
        public string m_endNameDayOfWeek { get; set; }
        public string m_DayToTour { get; set; } = "";
        

        public HomeViewModel(TourService tourService, IDialogService dialogService, Configuration configuration)
        {
            m_TourService = tourService;
            DialogService = dialogService;
            m_Configuration = configuration;
            Init();
        }
        
        public async void Init()
        {
            //m_vTour = new ObservableCollection<TourDTO>(await m_TourService.GetUsersTours(m_Configuration.User.Id));
            m_vTour.Add(new TourDTO { Title = "Wyjazd na Łódki 2023", EndDate = new DateTime(2023,8,5), StartDate = new DateTime(2023, 8, 9) ,CreateDate = new DateTime(2023,7,27)});
            m_vTour.Add(new TourDTO { Title = "Wyjazd w Pieniny 2023", EndDate = new DateTime(2023,9,10), StartDate = new DateTime(2024, 9, 6) ,CreateDate = new DateTime(2023,6,12)});
            m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2024", EndDate = new DateTime(2024, 2, 18), StartDate = new DateTime(2024, 2, 13), CreateDate = new DateTime(2023, 10, 24) });
            if (m_vTour == null || m_vTour.Count == 0)
            {
                await Shell.Current.GoToAsync("HomePageWithoutTours");
            }

            //m_NearestTour = await m_TourService.GetNearestTour(m_Configuration.User.Id);
            m_NearestTour = m_vTour[0];
            if(m_NearestTour == null)
            {
                DialogService.ShowAlert("Błąd połączenia!", "Nie udało się uzyskać informacji o pierwszej natchodzącej wycieczce!", "OK");
                return;
            }

            m_startNameDayOfWeek = m_Configuration.GetShortNameOfDayWeek(m_NearestTour.StartDate);
            m_endNameDayOfWeek = m_Configuration.GetShortNameOfDayWeek(m_NearestTour.EndDate);

            //Calculatin angle for Chart
            double totalDay = Math.Abs(m_NearestTour.CreateDate.Subtract(m_NearestTour.StartDate).TotalDays);
            double toStart = Math.Abs(m_NearestTour.StartDate.Subtract(DateTime.Today).TotalDays);

            if (toStart < 1)
            {
                m_fAngle = 91;
                m_DayToTour = "Dzisiaj";
            }
            else
            {
                if (toStart < 2)
                {
                    m_DayToTour = "Jutro";
                }
                else if (toStart < 3)
                {
                    m_DayToTour = "Pojutrze";
                }
                else
                    m_DayToTour = Convert.ToInt32(toStart) + " dni";
                
                m_fAngle = Convert.ToInt32(90 - (360 * (totalDay - toStart) / totalDay));
            }
        }


        [RelayCommand]
        async Task OpenCalendar()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        [RelayCommand]
        async Task CreateTrip()
        {
            await Shell.Current.GoToAsync("CreateTour1");
        }

        [RelayCommand]
        async Task ShowNotification()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
