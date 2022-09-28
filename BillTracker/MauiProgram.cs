using AppActions.Icons.Maui;
using CommunityToolkit.Maui;

namespace BillTracker;

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
			})
            .UseMauiCommunityToolkit()
			.ConfigureEssentials(essentials =>
            {
				essentials
					.UseAppActionIcons()
					.AddAppAction("home_sc", "Home", icon: AppActionIcon.Home)
					.OnAppAction(App.HandleAppActions)
					.AddAppAction("add_biller", "Add a Biller", icon: AppActionIcon.Contact);
            });

        return builder.Build();
	}
}

