using TripPlanner.Drawables;
using TripPlanner.ViewModels;

namespace TripPlanner.Views.HomeViews;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    public HomePage(HomeViewModel homeViewModel)
    {
        InitializeComponent();

        //var graphicsView = this.chart;
        //var chartDrawable = (ChartDrawable)graphicsView.Drawable;
        //chartDrawable.mAngle = homeViewModel.m_fAngle;

        BindingContext = homeViewModel;
    }
}