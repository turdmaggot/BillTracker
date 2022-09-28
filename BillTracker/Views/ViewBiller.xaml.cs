using BillTracker.Models;
using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class ViewBiller : ContentPage
{
    private ViewBillerViewModel _viewModel;

    public ViewBiller(Biller biller)
    {
        InitializeComponent();

        _viewModel = new ViewBillerViewModel(biller);
        this.BindingContext = _viewModel;
        this.Title = "Biller - " + _viewModel.Biller.BillerName;
    }
}
