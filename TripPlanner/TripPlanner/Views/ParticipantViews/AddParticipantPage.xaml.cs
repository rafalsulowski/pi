using TripPlanner.ViewModels;

namespace TripPlanner.Views.ParticipantViews;

public partial class AddParticipantPage : ContentPage
{
	public AddParticipantPage(AddParticipantsViewModel addParticipantsViewModel)
	{
		InitializeComponent();
		BindingContext = addParticipantsViewModel;
	}
}