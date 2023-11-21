using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.UserDTOs;
using TripPlanner.Models.Models;
using TripPlanner.Services;

namespace TripPlanner.ViewModels.User
{
    public partial class LoginViewModel : ObservableObject
    {
        private Configuration m_Configuration;
        private readonly UserService m_UserService;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        public LoginViewModel(Configuration configuration, UserService userService)
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
        async Task GoRegister()
        {
            await Shell.Current.GoToAsync($"/Start/Register");
        }

        [RelayCommand]
        async Task Submit()
        {
            //walidacja
            if(string.IsNullOrEmpty(Email))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Pole e-mail nie może być puste", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Pole hasła nie może być puste", "Ok");
                return;
            }
            //hasher do zakodowania hasla 
            RepositoryResponse<UserDTO> response = await m_UserService.Login(Email, Password);

            if(response.Success && response.Data != null)
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
