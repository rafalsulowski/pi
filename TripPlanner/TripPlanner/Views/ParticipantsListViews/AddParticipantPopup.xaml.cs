using CommunityToolkit.Maui.Views;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Views.ParticipantsListViews;

public partial class AddParticipantPopup : Popup
{
    private TourDTO Tour;
	public AddParticipantPopup(TourDTO tour)
	{
		InitializeComponent();
        LabelLink.Text = tour.InviteLink;
        Tour = tour;
    }

	public async void GoToFriendList_Cliked(object sender, EventArgs e)
	{
        await CloseAsync();

        var navigationParameter = new Dictionary<string, object>
            {
                { "passTourId",  Tour.Id}
            };
        await Shell.Current.GoToAsync($"AddParticipantFromFriends", navigationParameter);
    }
}