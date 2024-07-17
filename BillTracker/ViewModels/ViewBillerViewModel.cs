using System.Collections.ObjectModel;
using BillTracker.Helpers;
using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BillTracker.ViewModels
{
    public partial class ViewBillerViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        #region Properties

        private readonly SQLiteRepository _sqliteRepo;
        
        public ObservableCollection<Bill> Bills { get; set; } = new ObservableCollection<Bill>();

        private Biller _biller;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string Title
        {
            get
            {
                if (_biller != null)
                {
                    return $"Biller - {Biller.BillerName}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #region Constructor

        public ViewBillerViewModel(SQLiteRepository sQLiteRepository)
        {
            _sqliteRepo = sQLiteRepository;
        }

        #endregion

        #region Commands

        [RelayCommand]
        private async Task AddBillAsync()
        {
            // TODO: Add logic to add Bill

            await ToastUtility.ShowShortToast("Bill added.");
        }

        private async Task SelectedBillAsync()
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
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _biller = query["Biller"] as Biller;
            OnPropertyChanged(nameof(Biller));
        }

        #endregion

        #region Private Methods

        private void OnPropertyChanged(string propertyName)
        {
            if (propertyName.Equals(nameof(Biller), StringComparison.OrdinalIgnoreCase))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Biller)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        #endregion
    }
}