using TripPlanner.Pages.TripPages;

namespace TripPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("HomePage", typeof(HomePage));
		Routing.RegisterRoute("HomePageWithoutTours", typeof(HomePageWithoutTours));
		Routing.RegisterRoute("HomeChooseMenu", typeof(HomeChooseMenu));
		Routing.RegisterRoute("CreateTour1", typeof(CreateTour1));
	}
}
