using AppActions.Icons.Maui;
using BillTracker.Services;
using BillTracker.ViewModels;
using BillTracker.Views;
using CommunityToolkit.Maui;

namespace BillTracker;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .UseMauiCommunityToolkit();

        return builder.Build();
	}

	public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<SQLiteRepository>();

        // More services registered here.

        return mauiAppBuilder;        
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
		mauiAppBuilder.Services.AddSingleton<ViewBillerViewModel>();
		mauiAppBuilder.Services.AddSingleton<AddBillerViewModel>();


        // More view-models registered here.

        return mauiAppBuilder;        
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPage>();
		mauiAppBuilder.Services.AddSingleton<ViewBillerPage>();
		mauiAppBuilder.Services.AddSingleton<AddBillerPage>();

        // More views registered here.

        return mauiAppBuilder;        
    }
}

