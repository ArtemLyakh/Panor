﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Auth
{
    public class RegisterPageViewModel : BaseViewModel
    {
        Models.Auth.Register Model;

        public RegisterPageViewModel()
        {
            Model = new Models.Auth.Register();

            PersonalData = true;
        }


        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, val => 
            {
                Model.Name = val;
            });
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

        private string _confirm;
        public string Confirm
        {
            get => _confirm;
            set => SetProperty(ref _confirm, value, val => 
            {
                Model.Confirm = val;
            });
        }

        private bool _personalData;
        public bool PersonalData
        {
            get => _personalData;
            set => SetProperty(ref _personalData, value, val =>
            {
                Model.PersonalData = val;
            });
        }

        public ICommand ViewPersonalDataCommand => new Command(() =>
        {
            Device.OpenUri(new Uri(Config.Uri.PersonalDataUrl));
        });

		public ICommand LoginCommand => new Command(async () =>
		{
			await App.Current.Navigation.PushRoot(new Pages.Auth.LoginPage());
		});

        public ICommand RegisterCommand => new Command(Register);

        private async void Register()
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
                res = await App.Current.WebClient.SendAsync("POST", new Uri(Config.Uri.RegisterUrl), GetNewToken(), Model.GetJson());
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
