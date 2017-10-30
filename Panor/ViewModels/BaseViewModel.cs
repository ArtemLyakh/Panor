using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T storage, T value, Action callback = null, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return;

            storage = value;
            OnPropertyChanged(propertyName);
            callback?.Invoke();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
