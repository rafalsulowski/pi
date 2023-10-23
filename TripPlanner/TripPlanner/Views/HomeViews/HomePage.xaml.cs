using TripPlanner.ViewModels;

namespace TripPlanner.Views.HomeViews;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel homeViewModel)
    {
        InitializeComponent();
        BindingContext = homeViewModel;
    }
}