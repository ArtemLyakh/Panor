using System;
using System.Linq;
using System.Threading.Tasks;
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

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelToken();
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

        public ICommand RegisterCommand => new Command(async () =>
        {
            await App.Current.Navigation.PushRoot(new Pages.Auth.RegisterPage());
        });

        public ICommand LoginCommand => new Command(Login);

        private async void Login()
        {
            var errors = Model.GetErrors().ToList();
            if (errors.Count > 0)
            {
                App.Current.ToastService.Show(string.Join(Environment.NewLine, errors));
                return;
            }

            IsLoading = true;
            try
            {
                await App.Current.Api.Login(Model.GetJson(), GetNewToken());
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(ex.Message))
                    App.Current.ToastService.Show(ex.Message);

                return;
            }
            finally 
            {
                ClearToken();
                IsLoading = false;
            }


            App.Current.AuthService.Authorize(Email, Password);
            await App.Current.Navigation.PopToRoot();
        }


    }
}
