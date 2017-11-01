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

        public ICommand LoginCommand => new Command(async () =>
        {
            var errors = Model.GetErrors().ToList();

            if (errors.Count > 0)
            {
                App.Current.ToastService.Show(string.Join(Environment.NewLine, errors));
                return;
            }

            (int Code, string Response) res;
            IsLoading = true;
            try
            {
                res = await App.Current.WebClient.SendAsync("POST", new Uri(Config.Uri.LoginUrl), GetNewToken(), Model.GetJson());
            }
            catch (OperationCanceledException)
            {
                return;
            }
            catch (TimeoutException)
            {
                App.Current.ToastService.Show("Превышен интервал запроса");
                return;
            }
            catch
            {
                App.Current.ToastService.Show("Ошибка");
                return;
            }
            finally
            {
                IsLoading = false;
                ClearToken();
            }

            switch (res.Code)
            {
                case 200:
                    App.Current.AuthService.Authorize(Email, Password);
                    await App.Current.Navigation.PopToRoot();
                    return;
                case 401:
                    var error = Json.Error.ParseJson(res.Response);
                    if (error == null)
                    {
                        App.Current.ToastService.Show("Ошибка ответа сервера");
                        return;
                    }
                    else 
                    {
                        App.Current.ToastService.Show(error.message);
                        return;
                    }
                default: 
                    App.Current.ToastService.Show("Ошибка ответа сервера");
                    return;
            }

        });

        public ICommand RegisterCommand => new Command(async () =>
        {
            await App.Current.Navigation.PushRoot(new Pages.Auth.RegisterPage());
        });
    }
}
