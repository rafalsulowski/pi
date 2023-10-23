using TripPlanner.ViewModels;

namespace TripPlanner.Views.TourViews;

public partial class CreateTour : ContentPage
{
	public CreateTour(CreateTourViewModel createTourViewModel)
	{
		InitializeComponent();
        BindingContext = createTourViewModel;
	}
}