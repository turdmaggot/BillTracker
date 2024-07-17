using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();

        _viewModel = mainPageViewModel;
        this.BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.ShowBillers();
    }

    async void OnAddNewBiller(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(AddBillerPage)}");
    }

    protected override bool OnBackButtonPressed()
    {
         return true;
    }
}
