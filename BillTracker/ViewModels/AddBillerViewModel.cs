using System;
using System.Threading;
using System.Windows.Input;
using BillTracker.Models;
using BillTracker.Services;
using Microsoft.Maui;
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
            BillerName = billerObj.BillerName;
            BillerReferenceNo = billerObj.BillerReferenceNo;
            BillerType = billerObj.BillerType;
            _dateAdded = billerObj.DateAdded;

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

            await ShowToast("Biller added!");
            
            await App.Current.MainPage.Navigation.PopAsync();
        });

        #endregion

        #region Private Methods

        private async Task ShowToast(string message)
        {
            // TODO: Move this method in its own helper class after!
            // This code is placed here just for POC purposes!

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CommunityToolkit.Maui.Core.ToastDuration duration = CommunityToolkit.Maui.Core.ToastDuration.Short;
            double fontSize = 14;

            var toast = CommunityToolkit.Maui.Alerts.Toast.Make(message, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }

        #endregion
    }
}
