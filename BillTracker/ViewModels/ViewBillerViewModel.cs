using System;
using System.Collections.ObjectModel;
using BillTracker.Models;
using BillTracker.Services;

namespace BillTracker.ViewModels
{
    public class ViewBillerViewModel : BaseViewModel
    {
        #region Properties

        private readonly SQLiteRepository _sqliteRepo;

        private Biller _biller;
        public Biller Biller
        {
            get
            {
                return _biller;
            }
            set
            {
                _biller = value;
            }
        }

        #endregion

        #region Constructor

        public ViewBillerViewModel(Biller biller)
        {
            _sqliteRepo = new SQLiteRepository();
            Biller = biller;
        }

        #endregion
    }
}