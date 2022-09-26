using BillTracker.Models;
using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class AddBillerPage : ContentPage
{
	private AddBillerViewModel _viewModel;

	public AddBillerPage()
	{
		InitializeComponent();

		_viewModel = new AddBillerViewModel();
		this.BindingContext = _viewModel;
	}

	public AddBillerPage(Biller biller)
	{
        InitializeComponent();

        _viewModel = new AddBillerViewModel(biller);
        this.BindingContext = _viewModel;
    }
}
