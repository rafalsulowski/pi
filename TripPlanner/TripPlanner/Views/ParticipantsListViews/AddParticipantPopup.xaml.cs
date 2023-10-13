using CommunityToolkit.Maui.Views;
using TripPlanner.Models;
using TripPlanner.Models.DTO.TourDTOs;

namespace TripPlanner.Views.ParticipantsListViews;

public partial class AddParticipantPopup : Popup
{
    private TourDTO Tour;
	public AddParticipantPopup(TourDTO tour, string linkToJoin)
	{
		InitializeComponent();
        LabelLink.Text = linkToJoin;
        Tour = tour;
    }

	public async void GoToFriendList_Cliked(object sender, EventArgs e)
	{
        await CloseAsync();

        var navigationParameter = new Dictionary<string, object>
            {
                { "passTour",  Tour}
            };
        await Shell.Current.GoToAsync($"AddParticipantFromFriends", navigationParameter);
    }
}