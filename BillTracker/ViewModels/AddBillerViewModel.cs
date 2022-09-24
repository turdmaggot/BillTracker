using System;
using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;
using SQLite;

namespace BillTracker.ViewModels
{
    public class AddBillerViewModel : BaseViewModel
    {
        #region Properties

        private string _billerName;
        public string BillerName
        {
            get
            {
                return _billerName;
            }
            set
            {
                _billerName = value;
            }
        }

        private string _billerReferenceNo;
        public string BillerReferenceNo
        {
            get
            {
                return _billerReferenceNo;
            }
            set
            {
                _billerReferenceNo = value;
            }
        }

        private string _billerType;
        public string BillerType
        {
            get
            {
                return _billerType;
            }
            set
            {
                _billerType = value;
            }
        }


        private int _billerId;
        private DateTime _dateAdded;
        private readonly SQLiteRepository _sqliteRepo;

        #endregion

        #region Constructor

        public AddBillerViewModel()
        {
            _sqliteRepo = new SQLiteRepository();
        }

        public AddBillerViewModel(Biller billerObj)
        {
            _billerId = billerObj.BillerId;
            _dateAdded = billerObj.DateAdded;
            BillerName = billerObj.BillerName;
            BillerReferenceNo = billerObj.BillerReferenceNo;
            BillerType = billerObj.BillerType;

            _sqliteRepo = new SQLiteRepository();
        }

        #endregion

        #region Commands
        public ICommand AddBillerCommand => new Command(async () =>
        {
            Biller obj = new Biller
            {
                BillerName = BillerName,
                BillerReferenceNo = BillerReferenceNo,
                BillerType = BillerType,
                DateAdded = DateTime.Now,
                BillerId = _billerId
            };

            if (_billerId > 0)
                await _sqliteRepo.UpdateBiller(obj);
            else
                await _sqliteRepo.AddBiller(obj);

            await App.Current.MainPage.Navigation.PopAsync();
        });

        #endregion
    }
}
