using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using System.Collections.ObjectModel;
using System.Linq;
using TripPlanner.Models;
using TripPlanner.Models.DTO.ChatDTOs;
using TripPlanner.Models.DTO.QuestionnaireDTOs;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.Views.HomeViews;

namespace TripPlanner.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TourService m_TourService;
        private readonly IDialogService DialogService;
        private readonly Configuration m_Configuration;
        public ObservableCollection<TourDTO> m_vTour { get; set; } = new ObservableCollection<TourDTO> ();
        

        public HomeViewModel(TourService tourService, IDialogService dialogService, Configuration configuration)
        {
            m_TourService = tourService;
            DialogService = dialogService;
            m_Configuration = configuration;
            Init();
        }
        
        public async void Init()
        {
            m_vTour.Add(new TourDTO
            {
                Title = "Wyjazd na narty 2024",
                //Description = Description,
                //MaxParticipant = ParticipantMax,
                //TargetCountry = TargetCountry,
                CreateDate = DateTime.Now,
                StartDate = new DateTime(2024, 2, 15),
                EndDate = new DateTime(2024, 2, 15),
                Chat = new ChatDTO
                {
                    Id = 1,
                    Messages = new List<MessageDTO>
                    {
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Witam wszystkich na wyjeździe na narty 2023, odbędzie się on 11.02.2023 - 15.02.2023, na czacie tym możecie pisać wiadomości do siebie",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Cześć",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Cześć",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa4",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 2,
                            Content = "Wiadomość testowa5",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 2,
                            Content = "Wiadomość testowa6",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa7",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa8",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa9",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa10",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa11",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa12",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 3 ,
                            Content = "Wiadomość testowa13",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa14",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa15",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 2,
                            Content = "Wiadom ość testow a16 Wiadomość  test owa16 Wiadom ość te stowa16Wia domość testowa16 Wiadomość testow aw a16Wiado mość testowa 16Wiad o 16Wiado mość testowa 16Wiad omość  testowa16",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa17",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa18",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa19",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa20",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa21",
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa22",
                            Date = DateTime.Now,
                        },
                        new QuestionnaireDTO
                        {
                            UserId = 1,
                            Id = 123,
                            Content = "To jest ankieta?",
                            Answers = new List<QuestionnaireAnswerDTO>
                            {
                                new QuestionnaireAnswerDTO{
                                    Answer = "tak",
                                    Votes = new List<QuestionnaireVoteDTO>
                                    {
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 2 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 }
                                    }
                                },
                                new QuestionnaireAnswerDTO{ 
                                    Answer = "nie",
                                    Votes = new List<QuestionnaireVoteDTO>
                                    {
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 }
                                    }
                                },
                                new QuestionnaireAnswerDTO{ 
                                    Answer = "może",
                                    Votes = new List<QuestionnaireVoteDTO>
                                    {
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 },
                                        new QuestionnaireVoteDTO{ QuestionnaireAnswerId = 1, UserId = 1 }
                                    }
                                },
                            },
                            Date = DateTime.Now,
                        },
                        new TextMessageDTO
                        {
                            UserId = 1,
                            Content = "Wiadomość testowa23",
                            Date = DateTime.Now,
                        }
                    }
                }
            });

            //m_vTour.Add(new TourDTO { Title = "Wyjazd na Łódki 2023", EndDate = new DateTime(2023,8,5), StartDate = new DateTime(2023, 8, 9) ,CreateDate = new DateTime(2023,7,27)});
            //m_vTour.Add(new TourDTO { Title = "Wyjazd w Pieniny 2023", EndDate = new DateTime(2023,9,10), StartDate = new DateTime(2024, 9, 6) ,CreateDate = new DateTime(2023,6,12)});
            //m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2024", EndDate = new DateTime(2024, 2, 18), StartDate = new DateTime(2024, 2, 13), CreateDate = new DateTime(2023, 10, 24) });
            if (m_vTour == null || m_vTour.Count == 0)
            {
                await Shell.Current.GoToAsync("HomePageWithoutTours");
            }
        }


        [RelayCommand]
        async Task OpenCalendar()
        {
            await Shell.Current.GoToAsync("Calendar");
        }

        [RelayCommand]
        async Task CreateTrip()
        {
            await Shell.Current.GoToAsync("CreateTour");
        }

        [RelayCommand]
        async Task ShowTour(TourDTO tour)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  tour}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task ShowNotification()
        {
            await Shell.Current.GoToAsync("Notifications");
        }
    }
}
