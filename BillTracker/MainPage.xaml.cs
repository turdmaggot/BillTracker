namespace BillTracker;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    async void OnAddNewBiller(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddBillerPage());
    }
}
