using System;
using Microsoft.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace BillTracker.Helpers
{
    public static class ToastUtility
    {
        #region Constants

        private static readonly double DefaultFontSize = 14;

        #endregion

        #region Public Methods
        
        public async static Task ShowShortToast(string message)
        {
            await ShowToast(message, ToastDuration.Short, DefaultFontSize);
        }

        public async static Task ShowShortToast(string message, double fontSize)
        {
            await ShowToast(message, ToastDuration.Short, DefaultFontSize);
        }

        public async static Task ShowLongToast(string message)
        {
            await ShowToast(message, ToastDuration.Long, DefaultFontSize);
        }

        public async static Task ShowLongToast(string message, double fontSize)
        {
            await ShowToast(message, ToastDuration.Long, DefaultFontSize);
        }

        #endregion

        #region Private Methods

        private async static Task ShowToast(string message, ToastDuration duration, double fontSize)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var toast = Toast.Make(message, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }

        #endregion
    }
}
