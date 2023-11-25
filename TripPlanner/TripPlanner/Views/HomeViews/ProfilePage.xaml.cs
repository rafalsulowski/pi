using TripPlanner.ViewModels;
using TripPlanner.ViewModels.User;

namespace TripPlanner.Views.HomeViews;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = profileViewModel;
	}
}