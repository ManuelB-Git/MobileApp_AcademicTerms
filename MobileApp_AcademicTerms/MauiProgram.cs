using Microsoft.Extensions.Logging;
using MobileApp_AcademicTerms.Services;
using Plugin.LocalNotification;

namespace MobileApp_AcademicTerms;

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
			})
			// Initialize the local notification plugin
			.UseLocalNotification();

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		// Register services
		builder.Services.AddSingleton<DatabaseService>();
		
		// INotificationService is automatically registered by the Plugin.LocalNotification library
		// Make sure we register our NotificationService after it
		builder.Services.AddSingleton<NotificationService>();
		builder.Services.AddSingleton<SearchService>();

		return builder.Build();
	}
}
