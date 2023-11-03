using CommunityToolkit.Maui.Views;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.Views.ChatViews;

public partial class ChatAdditionalMenuPopup : Popup
{
    TourService m_TourService;
    TourDTO Tour;
	public ChatAdditionalMenuPopup(TourService tourService, TourDTO tour)
	{
		InitializeComponent();
        m_TourService = tourService;
        Tour = tour;
	}

    async void AddQuestionnaire(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour},
            };
        await CloseAsync();
        await Shell.Current.GoToAsync($"CreateQuestionnaire", navigationParameter);
    }

    async void ShowPeopleOnChat(object sender, EventArgs args)
    {
        var res = m_TourService.GetTourExtendParticipant(Tour.Id);

        if (res.Result != null)
        {
            await CloseAsync();
            await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups("Lista os�b czatu", res.Result));
        }
        else
            await Shell.Current.CurrentPage.DisplayAlert("B��d", "Nie uda�o si� pobra� listy os�b czatu!", "Ok");
    }
}