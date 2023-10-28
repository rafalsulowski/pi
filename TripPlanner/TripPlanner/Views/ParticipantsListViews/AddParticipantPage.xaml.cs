using TripPlanner.ViewModels;

namespace TripPlanner.Views.ParticipantsListViews;

public partial class AddParticipantPage : ContentPage
{
	public AddParticipantPage(AddParticipantsViewModel addParticipantsViewModel)
	{
		InitializeComponent();
		BindingContext = addParticipantsViewModel;
	}
}