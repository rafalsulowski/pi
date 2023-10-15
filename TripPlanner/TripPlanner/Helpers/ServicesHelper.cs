﻿
namespace TripPlanner.Helpers
{
    public static class ServicesHelper
    {
        public static TService GetService<TService>()
        {
            return Current.GetService<TService>();
        }
    
        public static IServiceProvider Current =>
        #if WINDOWS10_0_17763_0_OR_GREATER
                    MauiWinUIApplication.Current.Services;
        #elif ANDROID
                    MauiApplication.Current.Services;
        #elif IOS || MACCATALYST
                    MauiUIApplicationDelegate.Current.Services;
        #else
                    null;
        #endif
    }
}
