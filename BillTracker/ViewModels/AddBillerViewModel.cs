using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;
using BillTracker.Helpers;
using System.ComponentModel;
using BillTracker.Views;

namespace BillTracker.ViewModels
{
    public class AddBillerViewModel : BaseViewModel
    {
        #region Properties

        public Biller CurrentBiller { get; private set; }

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

        public AddBillerViewModel(SQLiteRepository sQLiteRepository)
        {
            _sqliteRepo = new SQLiteRepository();
        }

        #endregion

        #region Commands

        public ICommand AddBillerCommand => new Command(async () =>
        {
            // Reconsile ViewModel with actual Model here!
            Biller obj = new Biller
            {
                BillerId = _billerId,
                BillerName = BillerName,
                BillerReferenceNo = BillerReferenceNo,
                BillerType = BillerType,
                DateAdded = _dateAdded
            };

            if (_billerId > 0)
                await _sqliteRepo.UpdateBiller(obj);
            else
            {
                obj.DateAdded = DateTime.Now;
                await _sqliteRepo.AddBiller(obj);
            }

            await ToastUtility.ShowShortToast("Biller added.");
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        });

        #endregion
    }
}
