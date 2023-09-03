using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.ViewModels;

namespace TripPlanner.Views.TourViews;

public partial class TourPage : ContentPage
{
	public TourPage(TourViewModel tourViewModel)
	{
		InitializeComponent();
		BindingContext = tourViewModel;
	}
}