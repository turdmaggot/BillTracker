using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();

        _viewModel = mainPageViewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.ShowBillers();
    }

    protected override bool OnBackButtonPressed()
    {
         return true;
    }
}
