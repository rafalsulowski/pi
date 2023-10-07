using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TripPlanner.Views.HomeViews;
using TripPlanner.Views.StartViews;
using TripPlanner.Views.TourViews;
using TripPlanner.Services;
using TripPlanner.ViewModels;
using TripPlanner.Views;
using TripPlanner.Views.ChatViews;
using CommunityToolkit.Maui;
using TripPlanner.DataTemplates;
using HexInnovation;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//App Services
        builder.Services.AddSingleton<IDialogService, DialogService>();
        builder.Services.AddSingleton<Configuration>();
        builder.Services.AddSingleton<HttpClient>();

		//Data Template Selectors
        builder.Services.AddSingleton<MessageDataTemplateSelector>();
		builder.Services.AddSingleton<MathConverter>();

        //Data Managment Services
        builder.Services.AddSingleton<TourService>();
        builder.Services.AddSingleton<ChatService>();
        builder.Services.AddSingleton<QuestionnaireService>();
        
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

        //Views
        builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<CreateTour1>();
		builder.Services.AddTransient<HomePageWithoutTours>();
		builder.Services.AddTransient<CalendarPage>();
		builder.Services.AddTransient<NotificationPage>();
		builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<FriendsPage>();
		builder.Services.AddTransient<TourPage>();
		builder.Services.AddTransient<ChatPage>();
		builder.Services.AddTransient<CreateNewQuestionnairePage>();


		return builder.Build();
	}
}
