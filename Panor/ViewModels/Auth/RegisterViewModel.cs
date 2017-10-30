using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Auth
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirm;
        public string Confirm
        {
            get => _confirm;
            set => SetProperty(ref _confirm, value);
        }

        public ICommand ViewPersonalDataCommand => new Command(() =>
        {
            Device.OpenUri(new Uri(Config.PersonalDataUrl));
        });

        public ICommand RegisterCommand => new Command(() =>
        {
            throw new NotImplementedException();
        });

        public ICommand LoginCommand => new Command(async () =>
        {
            await App.Current.Navigation.PushRoot(new Pages.Auth.Login());
        });

    }
}
