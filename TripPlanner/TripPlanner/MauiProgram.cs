using TripPlanner.Views.HomeViews;
using TripPlanner.Views.StartViews;
using TripPlanner.Views.TourViews;
using TripPlanner.Services;
using TripPlanner.ViewModels;
using TripPlanner.Views.ChatViews;
using CommunityToolkit.Maui;
using TripPlanner.DataTemplates;
using TripPlanner.Views.ParticipantViews;
using TripPlanner.Views.ShareViews;

namespace TripPlanner;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
			});

        //App Services
        builder.Services.AddSingleton<Configuration>();

		builder.Services.AddHttpClient("httpClient")
			.ConfigurePrimaryHttpMessageHandler(() => {
                HttpClientHandler handler = new HttpClientHandler();
				handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
				{
					if (cert.Issuer.Equals("CN=localhost"))
						return true;
					return errors == System.Net.Security.SslPolicyErrors.None;
				};
				return handler;
			});


        //Data Template Selectors
        builder.Services.AddSingleton<MessageDataTemplateSelector>();
        builder.Services.AddSingleton<FriendDataTemplateSelector>();
        builder.Services.AddSingleton<ParticipantDataTemplateSelector>();


        //Data Managment Services
        builder.Services.AddSingleton<TourService>();
        builder.Services.AddSingleton<ChatService>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<ShareService>();
        builder.Services.AddSingleton<ScheduleService>();
        

		//ViewModels Services
		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<CreateTourViewModel>();
		builder.Services.AddTransient<NotificationViewModel>();
		builder.Services.AddTransient<CalendarViewModel>();
		builder.Services.AddTransient<FriendsViewModel>();
		builder.Services.AddTransient<ProfileViewModel>();
		builder.Services.AddTransient<TourViewModel>();
		builder.Services.AddTransient<ChatViewModel>();
		builder.Services.AddTransient<CreateQuestionnaireViewModel>();
		builder.Services.AddTransient<QuestionnaireViewModel>();
		builder.Services.AddTransient<ParticipantsViewModel>();
		builder.Services.AddTransient<AddParticipantsViewModel>();
		builder.Services.AddTransient<SharesViewModel>();


        //Views
        builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<CreateTour>();
		builder.Services.AddTransient<CalendarPage>();
		builder.Services.AddTransient<NotificationPage>();
		builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<FriendsPage>();
		builder.Services.AddTransient<TourPage>();
		builder.Services.AddTransient<ChatPage>();
		builder.Services.AddTransient<CreateNewQuestionnairePage>();
		builder.Services.AddTransient<ParticipantsListPage>();
		builder.Services.AddTransient<AddParticipantPage>();
		builder.Services.AddTransient<SharesListPage>();


		return builder.Build();
	}
}
