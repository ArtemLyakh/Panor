using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Auth
{
    public class LoginPageViewModel : BaseViewModel
    {
        private Models.Auth.Login Model;

        public LoginPageViewModel()
        {
            Model = new Models.Auth.Login();
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, val => 
            {
                Model.Email = val;
            });
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, val => 
            {
                Model.Password = val;
            });
        }

        public ICommand LoginCommand => new Command(async () =>
        {


            var cts = new System.Threading.CancellationTokenSource();
            //var res = await App.Current.WebClient.SendAsync(System.Net.Http.HttpMethod.Get, new Uri("http://panor.ru/api/qqq/"), cts.Token);

            var q = 1;
        });

        public ICommand RegisterCommand => new Command(async () =>
        {
            await App.Current.Navigation.PushRoot(new Pages.Auth.RegisterPage());
        });
    }
}
