using System.Collections.ObjectModel;
using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;
using BillTracker.Views;
using CommunityToolkit.Mvvm.Input;

namespace BillTracker.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<Biller> Billers { get; set; } = new ObservableCollection<Biller>();
        private readonly SQLiteRepository _sqliteRepo;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            _sqliteRepo = new SQLiteRepository();
        }

        #endregion

        #region Commands

        [RelayCommand]
        private async Task SelectBillerAsync(Biller biller)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Biller", biller }
            };
            
            await Shell.Current.GoToAsync($"//{nameof(ViewBillerPage)}", navigationParameter );
        }

        [RelayCommand]
        private async Task AddBillerAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(AddBillerPage)}");
        }

        #endregion

        #region Public Methods

        public async Task ShowBillers()
        {
            var billers = await _sqliteRepo.GetAllBillers();

            if (billers?.Count > 0)
            {
                Billers.Clear();
                foreach (var biller in billers)
                {
                    Billers.Add(biller);
                }
            }
        }

        #endregion
    }
}
