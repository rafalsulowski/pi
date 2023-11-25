using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
        string password2;

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
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "E-mail nie może być pusty", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(City))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Musisz podać aktualne miasto zamieszkania", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Address))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Musisz podać adress do korespondencji", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(FullName))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Musisz podać imię i nazwisko", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Hasło powinno posiadać co najmniej 8 znaków, jedną literę dużą, jedną małą, jedną cyfrę oraz znak specjalny", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Password2))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Hasło powinno posiadać co najmniej 8 znaków, jedną literę dużą, jedną małą, jedną cyfrę oraz znak specjalny", "Ok");
                return;
            }

            if(Password != Password2)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Hasła są różne", "Ok");
                return;
            }

            if(Password.Length < 8)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Hasło powinno posiadać co najmniej 8 znaków, jedną literę dużą, jedną małą, jedną cyfrę oraz znak specjalny", "Ok");
                return;
            }

            if (Password != Password2)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Hasła są różne", "Ok");
                return;
            }

            bool emailFree = await m_UserService.EmailIsFree(Email);

            if(!emailFree)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "E-mail jest już przypisany do innego konta", "Ok");
                return;
            }

            CreateUserDTO createUserDTO = new CreateUserDTO
            {
                City = City,
                DateOfBirth = DateOfBirth,
                Email = Email,
                FullAddress = Address,
                FullName = FullName,
                PasswordHash = Password,
            };

            RepositoryResponse<bool> response = await m_UserService.Register(createUserDTO);

            if (response.Success && response.Data)
            {
                var confirmCopyToast = Toast.Make("Popranie zajerestrowano", ToastDuration.Long, 14);
                await confirmCopyToast.Show();

                await Shell.Current.GoToAsync($"/Start/Login");
            }
            else
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", response.Message, "Ok");
                return;
            }
        }
    }
}

