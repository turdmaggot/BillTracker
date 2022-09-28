using BillTracker.Views;

namespace BillTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    public static void HandleAppActions(AppAction appAction)
    {
        App.Current.Dispatcher.Dispatch(async () =>
        {
            var page = appAction.Id switch
            {
                "home_sc" => new MainPage(),
                "add_biller" => new AddBillerPage(),
                _ => default(Page)
            };

            if (page != null)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });
    }
}

