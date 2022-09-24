using System;
using System.Collections.ObjectModel;
using BillTracker.Helpers;
using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;

namespace BillTracker.ViewModels
{
    public class ViewBillerViewModel : BaseViewModel
    {
        #region Properties

        private readonly SQLiteRepository _sqliteRepo;
        public ObservableCollection<Bill> Bills { get; set; } = new ObservableCollection<Bill>();

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

            // TODO: Get Bills from Biller, then put to Bills
        }

        #endregion

        #region Commands

        public ICommand AddBillCommand => new Command(async () =>
        {
            // TODO: Add logic to add Bill


            await ToastUtility.ShowShortToast("Bill added.");
        });

        public ICommand SelectedBillCommand => new Command<Bill>(async (bill) =>
        {
            string res = await App.Current.MainPage.DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

            switch (res)
            {
                case "Update":
                    // TODO
                    break;
                case "Delete":
                    // TODO
                    //int del = _sqliteRepo.DeleteBill(bill);
                    //if (del > 0)
                    //{
                    //    Bills.Remove(bill);
                    //}
                    break;
            }
        });

        #endregion
    }
}