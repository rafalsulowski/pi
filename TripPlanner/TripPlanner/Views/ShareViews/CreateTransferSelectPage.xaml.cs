using TripPlanner.ViewModels.Shares;

namespace TripPlanner.Views.ShareViews;

public partial class CreateTransferSelectPage : ContentPage
{
	public CreateTransferSelectPage(CreateTransferViewModel createTransferViewModel)
	{
		InitializeComponent();
		BindingContext = createTransferViewModel;
	}
}