using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Panor.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void OnAppearing() {}
        public virtual void OnDisappearing() {}

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private CancellationTokenSource CancellationTokenSource;

        protected CancellationToken GetNewToken()
        {
            CancellationTokenSource = new CancellationTokenSource();
            return CancellationTokenSource.Token;
        }
        protected void CancelToken()
        {
            CancellationTokenSource?.Cancel();
            ClearToken();
        }
        protected void ClearToken()
        {
            CancellationTokenSource = null;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T storage, T value, Action<T> callback = null, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return;

            storage = value;
            OnPropertyChanged(propertyName);
            callback?.Invoke(value);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
