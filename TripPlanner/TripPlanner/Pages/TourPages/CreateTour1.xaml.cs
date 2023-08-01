using TripPlanner.ViewModels;

namespace TripPlanner.Pages.TripPages;

public partial class CreateTour1 : ContentPage
{
	public CreateTour1(CreateTourViewModel createTourViewModel)
	{
		InitializeComponent();
		BindingContext = createTourViewModel;
	}
}