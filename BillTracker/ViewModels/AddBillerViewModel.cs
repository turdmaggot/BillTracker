using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;
using BillTracker.Helpers;
using System.ComponentModel;
using BillTracker.Views;

namespace BillTracker.ViewModels
{
    public class AddBillerViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Properties

        private Biller _biller;
        
        public Biller Biller
        {
            get 
            {  
                if (_biller == null)
                {
                    _biller = new Biller();
                }

                return _biller;
            }
            set 
            { 
                _biller = value; 
                NotifyPropertyChanged(nameof(Biller));
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (propertyName.Equals(nameof(Biller)))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Biller)));
            }
        }

        private readonly SQLiteRepository _sqliteRepo;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructor

        public AddBillerViewModel(SQLiteRepository sQLiteRepository)
        {
            _sqliteRepo = new SQLiteRepository();
        }

        #endregion

        private bool Validate()
        {
            bool hasMissingField = string.IsNullOrWhiteSpace(_biller.BillerName)
            || string.IsNullOrWhiteSpace(_biller.BillerReferenceNo)
            || string.IsNullOrWhiteSpace(_biller.BillerReferenceNo);

            return !hasMissingField;
        }

        #region Commands

        public ICommand AddBillerCommand => new Command(async () =>
        {
            if (Validate())
            {
                if (Biller.BillerId > 0)
                    await _sqliteRepo.UpdateBiller(_biller);
                else
                {
                    Biller.DateAdded = DateTime.Now;
                    await _sqliteRepo.AddBiller(_biller);
                }

                Biller = new Biller(); // Reset Biller, as this viewmodel is reused.

                await ToastUtility.ShowShortToast("Biller added.");
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
                await ToastUtility.ShowShortToast("Incomplete fields. Please check your inputs.");
        });

        #endregion
    }
}
