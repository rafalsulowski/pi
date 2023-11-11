using TripPlanner.ViewModels;

namespace TripPlanner.Views.ParticipantViews;

public partial class ParticipantsListPage : ContentPage
{
	public ParticipantsListPage(ParticipantsViewModel participantsListViews)
	{
		InitializeComponent();
		BindingContext = participantsListViews;
    }
}