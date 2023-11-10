using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ParticipantsListViews;

namespace TripPlanner.ViewModels
{
    public partial class ParticipantsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly TourService m_TourService;
        private ObservableCollection<ExtendParticipantDTO> ParticipantsRef;        
        private int TourId;
        private string InviteLink;

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
            await LoadData();
        }   

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"Tour", navigationParameter);
        }

        [RelayCommand]
        async Task Add()
        {
            if (IsOrganizer)
            {
                await Shell.Current.CurrentPage.ShowPopupAsync(new AddParticipantPopup(TourId, InviteLink));
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", $"Nie masz uprawnień do dodawania nowych uczestników", "Ok");

        }

        [RelayCommand]
        async Task Export()
        {
            var confirmCopyToast = Toast.Make("Funkcjonalność niezaimplementowana!", ToastDuration.Long, 14);
            await confirmCopyToast.Show();
        }

        [RelayCommand]
        public async Task ParticipantSearching(string query)
        {
            if (string.IsNullOrEmpty(query))
                Participants = ParticipantsRef;
            else
                Participants = ParticipantsRef.Where(i => i.FullName.StartsWith(query, StringComparison.OrdinalIgnoreCase)).ToObservableCollection();
        }

        [RelayCommand]
        public async Task GoToFriendsList()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"AddParticipantFromFriends", navigationParameter);
        }

        [RelayCommand]
        async Task LeftTour(ExtendParticipantDTO participant)
        {
            int organizers = Participants.Select(u => u.IsOrganizer).Where(u => u == true).Count();
            if (IsOrganizer && organizers <= 1)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Jesteś jedynym organiazatorem wyjazdu, nie możesz wyjśc ponieważ wyjazd musi mieć minimalnie jednego organiazatora", "Ok");
            }
            else
            {
                var res = await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Czy na pewno chcesz opuścić wyjazd?", "Dalej", "Anuluj");
                if (res)
                {
                    var response = await m_TourService.DeleteParticipant(TourId, participant.UserId);
                    if (response.Success)
                    {
                        var navigationParameter = new Dictionary<string, object> 
                        { 
                            { "Reload", true }
                        };
                        await Shell.Current.GoToAsync("//Home", navigationParameter);
                        var confirmCopyToast = Toast.Make($"Opuszczono wyjazd", ToastDuration.Long, 14);
                        await confirmCopyToast.Show();
                    }
                    else
                        await Shell.Current.CurrentPage.DisplayAlert("Błąd", response.Message, "Ok");
                }
            }
        }

        [RelayCommand]
        async Task DeleteParticipant(ExtendParticipantDTO participant)
        {
            if (IsOrganizer)
            {
                ExtendParticipantDTO actualParticipant = m_TourService.GetTourExtendParticipantById(TourId, participant.UserId).Result;
                if (actualParticipant == null)
                {
                    await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Ten użytkownik nie jest już uczestnikiem tej wycieczki, odświerz listę", "Ok");
                }
                else
                {
                    var response = await m_TourService.DeleteParticipant(TourId, participant.UserId);
                    if (response.Success)
                    {
                        await LoadData();
                        string name = participant.Nickname == "" ? participant.FullName : participant.Nickname;
                        var confirmCopyToast = Toast.Make($"Usunięto {name} z wyjazdu", ToastDuration.Long, 14);
                        await confirmCopyToast.Show();
                    }
                    else
                        await Shell.Current.CurrentPage.DisplayAlert("Błąd", response.Message, "Ok");
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
                            ExtendParticipantDTO actualParticipant = m_TourService.GetTourExtendParticipantById(TourId, participant.UserId).Result;
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
                                var response = await m_TourService.AddOrganizer(TourId, participant.UserId);
                                if (response.Success)
                                {
                                    await LoadData();
                                    string name = participant.Nickname == "" ? participant.FullName : participant.Nickname;
                                    var confirmCopyToast = Toast.Make($"{name} jest teraz organizatorem wyjazdu", ToastDuration.Long, 14);
                                    await confirmCopyToast.Show();
                                }
                                else
                                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", response.Message, "Ok");
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
                if (Participants.Select(u => u.IsOrganizer).Where(u => u == true).Count() == 1)
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
                            ExtendParticipantDTO actualParticipant = m_TourService.GetTourExtendParticipantById(TourId, participant.UserId).Result;
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
                                var response = await m_TourService.DeleteOrganizer(TourId, participant.UserId);
                                if (response.Success)
                                {
                                    await LoadData();
                                    string name = participant.Nickname == "" ? participant.FullName : participant.Nickname;
                                    var confirmCopyToast = Toast.Make($"{name} nie jest już organizatorem wyjazdu", ToastDuration.Long, 14);
                                    await confirmCopyToast.Show();
                                }
                                else
                                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", response.Message, "Ok");
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
            await Clipboard.Default.SetTextAsync(InviteLink);

            var confirmCopyToast = Toast.Make("Skopiowano do schowka", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
        }

        [RelayCommand]
        async Task RefreshView()
        {
            Refresh = true;

            await LoadData();
            var confirmCopyToast = Toast.Make("Odświerzono listę uczestników", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
            Refresh = false;
        }
        
        private async Task LoadData()
        {
            var res = await m_TourService.GetTourWithParticipants(TourId);
            if (res is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać danych wyjazdu", "Ok");
                return;
            }

            var val = res.Participants.First(u => u.UserId == m_Configuration.User.Id);
            if (val is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Brak ciebie na liście uczestników wyjazdu", "Ok");
                return;
            }

            var value = await m_TourService.GetTourExtendParticipant(TourId);
            if (value is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nie udało się pobrać listy uczestników wyjazdu", "Ok");
            }

            InviteLink = res.InviteLink;
            IsOrganizer = val.IsOrganizer;
            Participants = value.ToObservableCollection();
            ParticipantsRef = value.ToObservableCollection();
        }
    }
}
