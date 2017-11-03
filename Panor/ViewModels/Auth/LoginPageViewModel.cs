﻿using System;
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
            IsLoading = true;
            try
            {
                ErrorCheck();
                var res = await Send();
                Process(res);
            }
            catch
            {
                return;
            }
            finally 
            {
                IsLoading = false;
            }
        }

        private void ErrorCheck()
        {
            var errors = Model.GetErrors().ToList();

            if (errors.Count > 0)
            {
                App.Current.ToastService.Show(string.Join(Environment.NewLine, errors));
                throw new Exception();
            }
        }

        private async Task<(int Code, string Response)> Send()
        {
            (int Code, string Response) res;
            try
            {
                res = await App.Current.WebClient.SendAsync(System.Net.Http.HttpMethod.Post, new Uri(Config.Uri.LoginUrl), GetNewToken(), Model.GetJson());
            }
            catch (OperationCanceledException)
            {
                throw new Exception();
            }
            catch (TimeoutException)
            {
                App.Current.ToastService.Show("Превышен интервал запроса");
                throw new Exception();
            }
            catch
            {
                App.Current.ToastService.Show("Ошибка");
                throw new Exception();
            }
            finally
            {
                ClearToken();
            }

            return res;
        }

        private void Process((int Code, string Response) res)
        {
            switch (res.Code)
            {
                case 200:
                    App.Current.AuthService.Authorize(Email, Password);
                    App.Current.Navigation.PopToRoot();
                    return;
                case 400: case 401:
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
        }
    }
}
