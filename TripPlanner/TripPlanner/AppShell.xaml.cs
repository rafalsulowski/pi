namespace TripPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("HomePage", typeof(HomePage));
		Routing.RegisterRoute("MainPage", typeof(MainPage));
	}
}
