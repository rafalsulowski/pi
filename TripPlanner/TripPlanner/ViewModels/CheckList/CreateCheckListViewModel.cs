using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels.CheckList
{
    public class Tuple2String
    {
        public string Name { get; set; } = string.Empty;
        public string Multiplicity { get; set; } = string.Empty;
    }

    public partial class CreateCheckListViewModels : ObservableObject, IQueryAttributable
    {
        private readonly CheckListService m_CheckListService;
        private readonly Configuration m_Configuration;
        private int TourId;

        [ObservableProperty]
        ObservableCollection<Tuple2String> fields;

        [ObservableProperty]
        string name;


        [ObservableProperty]
        bool isPublic;

        public CreateCheckListViewModels(Configuration configuration, CheckListService checkListService)
        {
            m_Configuration = configuration;
            m_CheckListService = checkListService;
            IsPublic = false;
            Fields = new ObservableCollection<Tuple2String>();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            IsPublic = (bool)query["IsPublic"];
        }

        [RelayCommand]
        async Task GoBack()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId}
            };
            await Shell.Current.GoToAsync($"Tour/CheckLists", navigationParameter);
        }

        [RelayCommand]
        async Task AddAnswer()
        {
            Tuple2String result = (Tuple2String)await Shell.Current.CurrentPage.ShowPopupAsync(new AddCheckListFieldPopups(Fields.ToList()));
            if (result is not null)
            {
                Fields.Add(result);
            }
        }

        [RelayCommand]
        async Task DeleteAnswer(Tuple2String answer)
        {
            Fields.Remove(answer);
        }

        [RelayCommand]
        async Task Create()
        {
            if (string.IsNullOrEmpty(Name))
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nazwa nie może być pusta", "Ok");
            else
            {
                CreateCheckListDTO checkListDTO = new CreateCheckListDTO();
                checkListDTO.Name = Name;
                checkListDTO.TourId = TourId;
                checkListDTO.UserId = m_Configuration.User.Id;
                checkListDTO.IsPublic = IsPublic;

                foreach (var field in Fields)
                {
                    checkListDTO.Fields.Add(new CreateCheckListFieldDTO
                    {
                        Name = field.Name,
                        Multiplicity = field.Multiplicity,
                        CheckListId = 0
                    });
                }

                var result = await m_CheckListService.CreateCheckList(checkListDTO);

                if (result.Success && result.Data != -1)
                {
                    var confirmCopyToast = Toast.Make("Utworzono checkliste", ToastDuration.Short, 14);
                    await confirmCopyToast.Show();

                    var navigationParameter = new Dictionary<string, object>
                    {
                        { "passTourId",  TourId},
                        { "passCheckListId",  result.Data}
                    };
                    await Shell.Current.GoToAsync($"Tour/CheckLists/CheckList", navigationParameter);
                }
                else
                    await Shell.Current.CurrentPage.DisplayAlert("Błąd", result.Message, "Ok");
            }
        }
    }
}
