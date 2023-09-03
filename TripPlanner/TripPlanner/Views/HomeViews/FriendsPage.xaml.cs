using TripPlanner.ViewModels;

namespace TripPlanner.Views.HomeViews;

public partial class FriendsPage : ContentPage
{
    public FriendsPage(FriendsViewModel friendsViewModel)
	{
		InitializeComponent();
		BindingContext = friendsViewModel;
	}
}