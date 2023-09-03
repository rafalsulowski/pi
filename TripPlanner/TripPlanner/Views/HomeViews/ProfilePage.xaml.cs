using TripPlanner.ViewModels;

namespace TripPlanner.Views.HomeViews;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = profileViewModel;
	}
}