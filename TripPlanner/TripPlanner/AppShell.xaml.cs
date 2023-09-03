using TripPlanner.Views.HomeViews;
using TripPlanner.Views.TourViews;

namespace TripPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("Home", typeof(HomePage));
		Routing.RegisterRoute("HomePageWithoutTours", typeof(HomePageWithoutTours));
		Routing.RegisterRoute("CreateTour", typeof(CreateTour1));
		Routing.RegisterRoute("Calendar", typeof(CalendarPage));
		Routing.RegisterRoute("Notifications", typeof(NotificationPage));
		Routing.RegisterRoute("Profile", typeof(ProfilePage));
		Routing.RegisterRoute("Friends", typeof(FriendsPage));
		Routing.RegisterRoute("Tour", typeof(TourPage));
	}
}
