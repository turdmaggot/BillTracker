using System.Collections.ObjectModel;
using BillTracker.Models;
using BillTracker.Services;

namespace BillTracker.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
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
