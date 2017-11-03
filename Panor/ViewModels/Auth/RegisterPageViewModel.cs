using System;
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
            var errors = Model.GetErrors().ToList();
            if (errors.Count > 0)
            {
                App.Current.ToastService.Show(string.Join(Environment.NewLine, errors));
                return;
            }



            IsLoading = true;
            try
            {
                await App.Current.Api.Register(Model.GetJson(), GetNewToken());
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
                IsLoading = false;
            }


            App.Current.AuthService.Authorize(Email, Password);
            await App.Current.Navigation.PopToRoot();
        }

    }
}
