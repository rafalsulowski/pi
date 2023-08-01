using TripPlanner.Drawables;
using TripPlanner.Services;
using TripPlanner.ViewModels;

namespace TripPlanner;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel homeViewModel)
    {
        InitializeComponent();

        var graphicsView = this.chart;
        var chartDrawable = (ChartDrawable)graphicsView.Drawable;
        chartDrawable.mAngle = homeViewModel.m_fAngle;

        BindingContext = homeViewModel;
    }
}