using TripPlanner.Views.ChatViews;
using TripPlanner.Views.HomeViews;
using TripPlanner.Views.ParticipantViews;
using TripPlanner.Views.ShareViews;
using TripPlanner.Views.TourViews;

namespace TripPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("Home", typeof(HomePage));
		Routing.RegisterRoute("CreateTour", typeof(CreateTour));
		Routing.RegisterRoute("Calendar", typeof(CalendarPage));
		Routing.RegisterRoute("Notifications", typeof(NotificationPage));
		Routing.RegisterRoute("Profile", typeof(ProfilePage));
		Routing.RegisterRoute("Friends", typeof(FriendsPage));
		Routing.RegisterRoute("Tour", typeof(TourPage));
		Routing.RegisterRoute("Tour/Chat", typeof(ChatPage));
		Routing.RegisterRoute("Tour/Chat/CreateQuestionnaire", typeof(CreateNewQuestionnairePage));
		Routing.RegisterRoute("Tour/Participants", typeof(ParticipantsListPage));
		Routing.RegisterRoute("Tour/Participants/AddParticipantFromFriends", typeof(AddParticipantPage));
		Routing.RegisterRoute("Tour/Shares", typeof(SharesListPage));
		Routing.RegisterRoute("Tour/Shares/CreateBillPage", typeof(CreateBillPage));
		Routing.RegisterRoute("Tour/Shares/CreateBillPage/DivisionType", typeof(DivisionTypePage));
		Routing.RegisterRoute("Tour/Shares/Bill", typeof(BillPage));
		Routing.RegisterRoute("Tour/Shares/CreateTransferSelectPage", typeof(CreateTransferSelectPage));
		Routing.RegisterRoute("Tour/Shares/CreateTransferSelectPage/CreateTransferSubmitPage", typeof(CreateTransferSubmitPage));	
		Routing.RegisterRoute("Tour/Shares/Transfer", typeof(TransferPage));
		Routing.RegisterRoute("Tour/Shares/Balance", typeof(BalancePage));
	}
}
