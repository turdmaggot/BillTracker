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

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        return true;
    }
}
