using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Services;

namespace TripPlanner.ViewModels.User
{
    public partial class RegisterViewModel : ObservableObject
    {
        private Configuration m_Configuration;
        private readonly UserService m_UserService;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string fullName;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        DateTime dateOfBirth;

        [ObservableProperty]
        string address;

        [ObservableProperty]
        string city;

        public RegisterViewModel(Configuration configuration, UserService userService)
        {
            m_Configuration = configuration;
            m_UserService = userService;
        }
        

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync($"/Start");
        }

        [RelayCommand]
        async Task GoLogin()
        {
            await Shell.Current.GoToAsync($"/Start/Login");
        }

        [RelayCommand]
        async Task Submit()
        {
            //walidacja
            if (string.IsNullOrEmpty(Email))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Pole e-mail nie może być puste", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(City))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Musisz podać aktualne miasto zamieszkania", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Address))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Musisz podać adress", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(FullName))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Musisz podać imię i nazwisko", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Pole hasła nie może być puste", "Ok");
                return;
            }


            //hasher do zakodowania hasla 
            RepositoryResponse<UserDTO> response = await m_UserService.Login(Email, Password);

            if (response.Success && response.Data != null)
            {
                m_Configuration.User = response.Data;
                //ustawienie auth w httpClient na zwrocony JWT
            }
            else
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Błędne dane logowania", "Ok");
                return;
            }


            var navigationParameter = new Dictionary<string, object>
            {
                { "Reload",  false}
            };
            await Shell.Current.GoToAsync($"/Home", navigationParameter);
        }
    }
}

