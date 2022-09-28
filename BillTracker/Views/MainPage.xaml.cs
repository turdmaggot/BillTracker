using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;

    public MainPage()
	{
		InitializeComponent();

        _viewModel = new MainPageViewModel();
        this.BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.ShowBillers();
    }

    async void OnAddNewBiller(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddBillerPage());
    }
}
