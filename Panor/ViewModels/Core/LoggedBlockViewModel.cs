using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Core
{
    public class LoggedBlockViewModel : BaseViewModel
    {
        private Models.Auth.LoggedBlock Model;

        public LoggedBlockViewModel()
        {
            Model = new Models.Auth.LoggedBlock();

            if (App.Current.AuthService.IsLogged)
            {
                Load();
            }

            MessagingCenter.Subscribe<Services.Auth.AuthService>(this, "Auth", auth =>
            {
                if (auth.IsLogged)
                {
                    Load();
                }
            });
        }

        private string _fio;
        public string Fio
        {
            get => _fio;
            set => SetProperty(ref _fio, value, val =>
            {
                Model.Fio = val;
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

        private ImageSource _image;
        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value, val =>
            {
                Model.Image = (val as UriImageSource)?.Uri;
            });
        }

        private Views.LoadingContentViewState _viewState;
        public Views.LoadingContentViewState ViewState
        {
            get => _viewState;
            set => SetProperty(ref _viewState, value);
        }

        public ICommand RepeatCommand => new Command(Load);

        private async void Load()
        {
            ViewState = Views.LoadingContentViewState.Loading;

            Models.Auth.LoggedBlock res;
            try
            {
                res = await App.Current.Api.GetLoggedBlockInfo(GetNewToken());
            }
            catch
            {
                ViewState = Views.LoadingContentViewState.Reload;
                return;
            }
            finally
            {
                ClearToken();
            }
            ViewState = Views.LoadingContentViewState.Content;


            if (res.Image != null)
                Image = ImageSource.FromUri(res.Image);
            else
                Image = ImageSource.FromFile("no_photo");

            Fio = res.Fio;
            Email = res.Email;
        }

    }
}
