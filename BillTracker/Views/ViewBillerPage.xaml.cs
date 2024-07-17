using BillTracker.Models;
using BillTracker.ViewModels;

namespace BillTracker.Views;

public partial class ViewBillerPage : ContentPage
{
    public ViewBillerPage(ViewBillerViewModel viewBillerViewModel)
    {
        InitializeComponent();
        BindingContext = viewBillerViewModel;
    }
}
