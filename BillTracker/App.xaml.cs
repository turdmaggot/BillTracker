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
        // App.Current.Dispatcher.Dispatch(async () =>
        // {
        //     string navTo = string.Empty;

        //     switch(appAction.Id)
        //     {
        //         case "add_biller":
        //             navTo = "AddBillerPage";
        //             break;
        //         default:
        //             navTo = "MainPage";
        //             break;
        //     }

        //     await Shell.Current.GoToAsync($"//{navTo}");
        // });
    }
}

