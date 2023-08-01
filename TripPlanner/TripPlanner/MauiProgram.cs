using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TripPlanner.Pages.TripPages;
using TripPlanner.Services;
using TripPlanner.ViewModels;

namespace TripPlanner;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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

        //Data Managment Services
        builder.Services.AddSingleton<TourService>();
        
		//ViewModels Services
		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<CreateTourViewModel>();

        //View Services
        builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<CreateTour1>();
		builder.Services.AddTransient<HomePageWithoutTours>();


		return builder.Build();
	}
}
