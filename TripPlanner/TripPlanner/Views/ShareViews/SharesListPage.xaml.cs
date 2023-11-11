using TripPlanner.ViewModels;

namespace TripPlanner.Views.ShareViews;

public partial class SharesListPage : ContentPage
{
	public SharesListPage(SharesViewModel sharesViewModel)
	{
		InitializeComponent();
		BindingContext = sharesViewModel;
    }
}