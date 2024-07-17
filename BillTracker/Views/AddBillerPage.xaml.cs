using BillTracker.Models;
using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class AddBillerPage : ContentPage
{
	private AddBillerViewModel _viewModel;

	public AddBillerPage(AddBillerViewModel addBillerViewModel)
	{
        InitializeComponent();

        _viewModel = addBillerViewModel;
        this.BindingContext = _viewModel;
    }
}
