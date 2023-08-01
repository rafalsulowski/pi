using TripPlanner.Drawables;
using TripPlanner.Models.DTO.TourDTOs;
using TripPlanner.Services;
using TripPlanner.ViewModels;

namespace TripPlanner;

public partial class HomeChooseMenu : ContentPage
{
	public HomeChooseMenu(HomeViewModel homeViewModel)
	{
		InitializeComponent();

        var graphicsView = this.chart;
        var chartDrawable = (ChartDrawable)graphicsView.Drawable;
        chartDrawable.mAngle = 180;


        //HomeViewModel viewModel = new HomeViewModel(tourService, dialogService);
        //viewModel.m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2024", StartDate = new DateTime(2024, 2, 12, 6, 30, 0), EndDate = new DateTime(2024, 2, 16, 19, 30, 0) });
        //viewModel.m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2025", StartDate = new DateTime(2025, 2, 12, 6, 30, 0), EndDate = new DateTime(2025, 2, 16, 19, 30, 0) });
        //viewModel.m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2026", StartDate = new DateTime(2026, 2, 12, 6, 30, 0), EndDate = new DateTime(2026, 2, 16, 19, 30, 0) });
        //viewModel.m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2026", StartDate = new DateTime(2026, 2, 12, 6, 30, 0), EndDate = new DateTime(2026, 2, 16, 19, 30, 0) });
        //viewModel.m_vTour.Add(new TourDTO { Title = "Wyjazd na narty 2026", StartDate = new DateTime(2026, 2, 12, 6, 30, 0), EndDate = new DateTime(2026, 2, 16, 19, 30, 0) });

        BindingContext = homeViewModel;
    }
}