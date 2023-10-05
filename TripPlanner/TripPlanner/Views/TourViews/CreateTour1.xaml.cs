
using TripPlanner.ViewModels;

namespace TripPlanner.Views.TourViews;

public partial class CreateTour1 : ContentPage
{
	public CreateTour1(CreateTourViewModel createTourViewModel)
	{
		InitializeComponent();
        BindingContext = createTourViewModel;
	}
}