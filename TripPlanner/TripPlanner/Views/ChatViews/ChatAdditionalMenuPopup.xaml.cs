using CommunityToolkit.Maui.Views;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;

namespace TripPlanner.Views.ChatViews;

public partial class ChatAdditionalMenuPopup : Popup
{
    TourService m_TourService;
    int TourId;
	public ChatAdditionalMenuPopup(TourService tourService, int tourId)
	{
		InitializeComponent();
        m_TourService = tourService;
        TourId = tourId;
	}

    async void AddQuestionnaire(object sender, EventArgs args)
    {
        var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  TourId},
            };
        await CloseAsync();
        await Shell.Current.GoToAsync($"CreateQuestionnaire", navigationParameter);
    }

    async void ShowPeopleOnChat(object sender, EventArgs args)
    {
        List<ExtendParticipantDTO> list = await m_TourService.GetTourExtendParticipant(TourId);
        await CloseAsync();
        await Shell.Current.CurrentPage.ShowPopupAsync(new PeopleChatListPopups("Lista osób czatu", list));
    }
}