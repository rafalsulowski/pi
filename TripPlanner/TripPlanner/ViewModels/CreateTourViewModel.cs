using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels
{
    public partial class CreateTourViewModel : ObservableObject
    {
        private readonly TourService m_TourService;
        private readonly IDialogService DialogService;
        private readonly Configuration m_Configuration;
        public ObservableCollection<TourDTO> m_vTour { get; set; } = new ObservableCollection<TourDTO>();
        public ObservableCollection<string> m_vCurrent { get; set; } = new ObservableCollection<string>();

        [ObservableProperty]
        string dateTerm;

        [ObservableProperty]
        int participantMax;

        [ObservableProperty]
        string targetCountry;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        string description;

        public CreateTourViewModel(TourService tourService, IDialogService dialogService, Configuration configuration)
        {
            m_TourService = tourService;
            DialogService = dialogService;
            m_Configuration = configuration;

            DateTerm = "11.05.2023 - 25.05.2023";
            ParticipantMax = 13;

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
                UserId = m_Configuration.User.Id,
                CreateDate = DateTime.Now,
                StartDate = new DateTime(2024, 2, 15),
                EndDate = new DateTime(2024, 2, 15)
            };


            //pobierz nowo utowrzona wycieczke dla sprawdzenia

            TourDTO newTourFromApi = new TourDTO
            {

                Title = Title,
                Description = Description,
                MaxParticipant = ParticipantMax,
                TargetCountry = TargetCountry,
                CreateDate = DateTime.Now,
                StartDate = new DateTime(2024, 2, 15),
                EndDate = new DateTime(2024, 2, 15),
                Chat = new Chat
                {
                    Id = 1,
                    Messages = new List<Message>
                    {
                        new Message
                        {
                            Content = "Wiadomość testowa",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa2",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa3",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa4",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa5",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa6",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa7",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa8",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa9",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa10",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa11",
                            Date = DateTime.Now,
                        },
                        new Message
                        {
                            Content = "Wiadomość testowa12",
                            Date = DateTime.Now,
                        }
                    }
                }
            };


            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  newTourFromApi}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

    }
}
