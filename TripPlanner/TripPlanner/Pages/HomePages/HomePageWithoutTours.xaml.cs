
namespace TripPlanner;
public partial class HomePageWithoutTours : ContentPage
{
	public HomePageWithoutTours()
	{
		InitializeComponent();
    }
    
    async void CreateTrip(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("CreateTour1");
    }

    async void OpenCalendar(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}