using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models.DTO.BillDTOs;
using TripPlanner.Services;

namespace TripPlanner.ViewModels.Shares
{
    public partial class BalanceViewModel : ObservableObject, IQueryAttributable
    {
        private readonly Configuration m_Configuration;
        private readonly ShareService m_ShareService;
        private int TourId;

        [ObservableProperty]
        Balance balance;

        [ObservableProperty]
        bool refresh;

        public BalanceViewModel(Configuration configuration, ShareService shareService)
        {
            m_Configuration = configuration;
            m_ShareService = shareService;
            Refresh = false;
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
            await Shell.Current.GoToAsync($"/Tour/Shares", navigationParameter);
        }

        [RelayCommand]
        async Task GoSettleUp()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId},
                { "passTransfer",  null},
                { "SelectRecipient",  false},
                { "IsAllParticipantMode",  false},
            };
            await Shell.Current.GoToAsync($"/CreateTransferSelect", navigationParameter);
        }

        [RelayCommand]
        async Task GoRemind()
        {
            //TODO
        }

        [RelayCommand]
        async Task ChangeExpandList(UserBalance ot)
        {
            ot.IsExpand = !ot.IsExpand;
        }
        

        [RelayCommand]
        async Task RefreshView()
        {
            Refresh = true;
            await LoadData();

            var confirmCopyToast = Toast.Make("Odświerzono listę rachunków", ToastDuration.Short, 14);
            await confirmCopyToast.Show();
            Refresh = false;
        }

        private async Task LoadData()
        {
            var result = await m_ShareService.GetBalance(TourId);

            if (!result.Success)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Błąd", result.Message, "Ok");
            }
            else
            {
                Balance = result.Data;
            }
        }
    }
}
