
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ParticipantsListViews;

namespace TripPlanner.ViewModels
{

    [QueryProperty("passTourId", "TourId")]
    public partial class ParticipantsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private ObservableCollection<ExtendParticipantDTO> ParticipantsRef;

        [ObservableProperty]
        TourDTO tour;
        
        [ObservableProperty]
        int tourId;

        [ObservableProperty]
        bool refresh;

        [ObservableProperty]
        bool isOrganizer;

        [ObservableProperty]
        ObservableCollection<ExtendParticipantDTO> participants;

        public ParticipantsViewModel(Configuration configuration, TourService tourService)
        {
            m_Configuration = configuration;
            m_TourService = tourService;
            Participants = new ObservableCollection<ExtendParticipantDTO>();
            ParticipantsRef = new ObservableCollection<ExtendParticipantDTO>();
            IsOrganizer = false;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            await RefreshViewAfterModify();
        }   

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  Tour.Id}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task Add()
        {
            if (IsOrganizer)
            {
                var result = await Shell.Current.CurrentPage.ShowPopupAsync(new AddParticipantPopup(Tour));
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie masz uprawnień do dodawania nowych uczestników", "Ok");

        }

        [RelayCommand]
        async Task Export()
        {
            await Task.Delay(100);
        }

        [RelayCommand]
        public async Task ParticipantSearching(string query)
        {
            if (string.IsNullOrEmpty(query))
                Participants = ParticipantsRef;
            else
                Participants = ParticipantsRef.Where(i => i.FullName.StartsWith(query, StringComparison.OrdinalIgnoreCase))?.ToObservableCollection();
        }

        [RelayCommand]
        public async Task GoToFriendsList()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
            await Shell.Current.GoToAsync($"AddParticipantFromFriends", navigationParameter);
        }

        [RelayCommand]
        async Task DeleteParticipant(ExtendParticipantDTO participant)
        {
            if (IsOrganizer)
            {
                ExtendParticipantDTO actualParticipant = m_TourService.GetTourExtendParticipantById(Tour.Id, participant.UserId).Result;
                if (actualParticipant == null)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik nie jest już uczestnikiem tej wycieczki, odświerz listę", "Ok");
                }
                else
                {
                    var response = await m_TourService.DeleteParticipant(Tour.Id, participant.UserId);
                    if (response)
                    {
                        await RefreshViewAfterModify();
                        string name = participant.Nickname == "" ? participant.FullName : participant.Nickname;
                        var confirmCopyToast = Toast.Make($"Usunięto {name} z wyjazdu", ToastDuration.Long, 14);
                        await confirmCopyToast.Show();
                    }
                    else
                    {
                        await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie udało się usunąć {participant.FullName} z wyjazdu", "Ok");
                    }
                }
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie masz uprawnień do usówania osób z wyjazdu", "Ok");
        }


            [RelayCommand]
        async Task MakeOrganizer(ExtendParticipantDTO participant)
        {
            if (IsOrganizer)
            {
                if (participant.IsOrganizer)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik jest już organizatorem tej wycieczki, odświerz listę", "Ok");
                }
                else
                {
                    var res = await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Spowoduje to, że nowy organizator będzie mieć dostęp do wszystkich czynności, takich jakie ty masz, nie udzielaj pozwoleń ograniazatora osobom do których nie masz zaufania.", "Dalej", "Anuluj");
                    if (res)
                    {
                        Random rnd = new Random();
                        int a = rnd.Next(0, 10);
                        int b = rnd.Next(0, 10);
                        int c = a + b;
                        string result = await Shell.Current.CurrentPage.DisplayPromptAsync("Walidacja", $"Podaj wynik działania: {a} + {b} = ?", initialValue: "0", maxLength: 2, keyboard: Keyboard.Numeric);

                        if (result != c.ToString())
                            await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Walidacja niepoprawna! Operacja anulowana.", "Ok");
                        else
                        {
                            ExtendParticipantDTO actualParticipant = m_TourService.GetTourExtendParticipantById(Tour.Id, participant.UserId).Result;
                            if (actualParticipant == null)
                            {
                                await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik nie jest już uczestnikiem tej wycieczki, odświerz listę", "Ok");
                            }
                            else if (actualParticipant.IsOrganizer)
                            {
                                await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik jest już organizatorem tej wycieczki, odświerz listę", "Ok");
                            }
                            else if (actualParticipant != null && actualParticipant.IsOrganizer == false)
                            {
                                var response = await m_TourService.AddOrganizer(Tour.Id, participant.UserId);
                                if (response)
                                {
                                    await RefreshViewAfterModify();
                                    string name = participant.Nickname == "" ? participant.FullName : participant.Nickname;
                                    var confirmCopyToast = Toast.Make($"{name} jest teraz organizatorem wyjazdu", ToastDuration.Long, 14);
                                    await confirmCopyToast.Show();
                                }
                                else
                                {
                                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie udało się mianować {participant.FullName} organizatorem", "Ok");
                                }
                            }
                        }
                    }
                }
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie masz uprawnień do nadawania rangi organizatora", "Ok");
        }

        [RelayCommand]
        async Task DeleteOrganizer(ExtendParticipantDTO participant)
        {
            if (IsOrganizer)
            {
                if (Participants.Select(u => u.IsOrganizer).ToList().Count == 1)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Wyjazd musi posiadać minimalnie jendego organiazatora", "Ok");
                    return;
                }

                if (!participant.IsOrganizer)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik nie jest już organizatorem tej wycieczki, odświerz listę", "Ok");
                }
                else
                {
                    var res = await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Spowoduje to, że uczestnik nie będzie mieć dostępu do wszystkich czynności, takich jakie posiada organizator.", "Dalej", "Anuluj");
                    if (res)
                    {
                        Random rnd = new Random();
                        int a = rnd.Next(0, 10);
                        int b = rnd.Next(0, 10);
                        int c = a + b;
                        string result = await Shell.Current.CurrentPage.DisplayPromptAsync("Walidacja", $"Podaj wynik działania: {a} + {b} = ?", initialValue: "", maxLength: 2, keyboard: Keyboard.Numeric);

                        if (result != c.ToString())
                            await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Walidacja niepoprawna! Operacja anulowana.", "Ok");
                        else
                        {
                            ExtendParticipantDTO actualParticipant = m_TourService.GetTourExtendParticipantById(Tour.Id, participant.UserId).Result;
                            if (actualParticipant == null)
                            {
                                await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik nie jest już uczestnikiem tej wycieczki, odświerz listę", "Ok");
                            }
                            else if (!actualParticipant.IsOrganizer)
                            {
                                await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik nie jest już organizatorem tej wycieczki, odświerz listę", "Ok");
                            }
                            else if (actualParticipant != null && actualParticipant.IsOrganizer == true)
                            {
                                var response = await m_TourService.DeleteOrganizer(Tour.Id, participant.UserId);
                                if (response)
                                {
                                    await RefreshViewAfterModify();
                                    string name = participant.Nickname == "" ? participant.FullName : participant.Nickname;
                                    var confirmCopyToast = Toast.Make($"{name} nie jest już organizatorem wyjazdu", ToastDuration.Long, 14);
                                    await confirmCopyToast.Show();
                                }
                                else
                                {
                                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie udało się mianować {participant.FullName} organizatorem", "Ok");
                                }
                            }
                        }
                    }
                }
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie masz uprawnień do zdejmowania rangi organizatora", "Ok");
        }

        [RelayCommand]
        public async Task CopyToClipboard()
        {
            await Clipboard.Default.SetTextAsync(Tour.InviteLink);

            var confirmCopyToast = Toast.Make("Skopiowano do schowka", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
        }

        [RelayCommand]
        async Task RefreshView()
        {
            Refresh = true;
            LoadData();

            var confirmCopyToast = Toast.Make("Odświerzono listę uczestników", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
            Refresh = false;
        }
        private async Task RefreshViewAfterModify()
        {
            Tour = await m_TourService.GetTourWithParticipants(TourId);

            if(Tour is null)
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać informacji o wyjeździe", "Ok");

            IsOrganizer = Tour.Participants.First(u => u.UserId == m_Configuration.User.Id).IsOrganizer;
            LoadData();
        }

        private async void LoadData()
        {
            var value = m_TourService.GetTourExtendParticipant(Tour.Id).Result;

            if (value is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy uczestników wyjazdu", "Ok");
            }
            else
            {
                Participants = value.ToObservableCollection();
                ParticipantsRef = value.ToObservableCollection();
            }
        }
    }
}
