using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.CheckListDTOs;
using TripPlanner.Services;
using TripPlanner.Views.ChatViews;

namespace TripPlanner.ViewModels.CheckList
{
    public partial class CheckListViewModel : ObservableObject, IQueryAttributable
    {
        private readonly CheckListService m_CheckListService;
        private readonly Configuration m_Configuration;
        private int TourId;
        private int CheckListId;

        [ObservableProperty]
        CheckListDTO checkList;


        public CheckListViewModel(Configuration configuration, CheckListService checkListService)
        {
            m_CheckListService = checkListService;
            m_Configuration = configuration;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            TourId = (int)query["passTourId"];
            CheckListId = (int)query["passCheckListId"];
            await LoadData();
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
        async Task DeleteCheckList()
        {
            var resp = await m_CheckListService.DeleteCheckList(CheckListId, m_Configuration.User.Id);

            if(resp.Success)
            {
                var confirmCopyToast = Toast.Make($"Usunięto checkliste", ToastDuration.Short, 14);
                await confirmCopyToast.Show();
                var navigationParameter = new Dictionary<string, object>
                {
                    { "passTourId",  TourId}
                };
                await Shell.Current.GoToAsync($"Tour/CheckLists", navigationParameter);
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", resp.Message, "Ok");
        }

        [RelayCommand]
        async Task ChangeVisibilityCheckList()
        {
            string str = "";
            if (CheckList.IsPublic)
                str = "prywatna";
            else
                str = "publiczna";

            var res = await Shell.Current.CurrentPage.DisplayAlert("Uwaga", $"Czy na pewno chcesz aby checklista była od teraz {str}?", "Tak", "Nie");
            if (!res)
                return;

            EditCheckListDTO edit = new EditCheckListDTO();
            edit.IsPublic = !CheckList.IsPublic;
            edit.Name = CheckList.Name;

            var resp = await m_CheckListService.UpdateCheckList(CheckListId, m_Configuration.User.Id, edit);

            if (resp.Success)
            {
                str = "";
                if (edit.IsPublic)
                    str = "publiczna";
                else
                    str = "prywatna";

                var confirmCopyToast = Toast.Make("Checklista jest teraz " + str, ToastDuration.Short, 14);
                await confirmCopyToast.Show();
                await LoadData();
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", resp.Message, "Ok");
        }

        [RelayCommand]
        async Task ChangeNameCheckList()
        {
            var result = await Shell.Current.CurrentPage.DisplayPromptAsync("Wprowadź nową nazwę checklisty", "", "OK", "Anuluj");

            string answer = result.ToString().TrimStart().TrimEnd();
            if (string.IsNullOrEmpty(answer))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", "Nowa nazwa nie może być pusta", "Ok");
                return;
            }

            EditCheckListDTO edit = new EditCheckListDTO();
            edit.IsPublic = CheckList.IsPublic;
            edit.Name = answer;

            var resp = await m_CheckListService.UpdateCheckList(CheckListId, m_Configuration.User.Id, edit);

            if (resp.Success)
            {
                var confirmCopyToast = Toast.Make($"Zmodyfikowano nazwę checklisty", ToastDuration.Short, 14);
                await confirmCopyToast.Show();
                await LoadData();
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", resp.Message, "Ok");
        }

        [RelayCommand]
        async Task DeleteField(CheckListFieldDTO field)
        {
            var res = await Shell.Current.CurrentPage.DisplayAlert("Uwaga", "Czy na pewno chcesz usunąć pole z checklisty?", "Tak", "Nie");
            if (!res)
                return;

            var resp = await m_CheckListService.DeleteCheckListField(CheckListId, field.Id, m_Configuration.User.Id);

            if (resp.Success)
            {
                var confirmCopyToast = Toast.Make($"Usunięto pole z checklisty", ToastDuration.Short, 14);
                await confirmCopyToast.Show();
                await LoadData();
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", resp.Message, "Ok");
        }

        [RelayCommand]
        async Task AddField()
        {
            List<Tuple2String> list = new List<Tuple2String>();
            foreach (var item in CheckList.Fields)
                list.Add(new Tuple2String { Name = item.Name, Multiplicity = item.Multiplicity });

            Tuple2String result = (Tuple2String)await Shell.Current.CurrentPage.ShowPopupAsync(new AddCheckListFieldPopups(list));
            if (result is null)
                return;

            CreateCheckListFieldDTO field = new CreateCheckListFieldDTO();
            field.CheckListId = CheckListId;
            field.Name = result.Name;
            field.Multiplicity = result.Multiplicity;

            var resp = await m_CheckListService.AddCheckListField(field, m_Configuration.User.Id);

            if (resp.Success)
            {
                var confirmCopyToast = Toast.Make($"Dodano pole do checklisty", ToastDuration.Short, 14);
                await confirmCopyToast.Show();
                await LoadData();
            }
            else
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", resp.Message, "Ok");
        }

        private async Task LoadData()
        {
            var res = await m_CheckListService.GetCheckListById(CheckListId);
            CheckList = res;
        }
    }
}
