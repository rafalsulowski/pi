using TripPlanner.ViewModels;

namespace TripPlanner.Views.ParticipantsListViews;

public partial class ParticipantsListPage : ContentPage
{
	public ParticipantsListPage(ParticipantsViewModel participantsListViews)
	{
		InitializeComponent();
		BindingContext = participantsListViews;
    }
}