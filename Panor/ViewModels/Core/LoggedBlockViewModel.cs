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

            HideAll();

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
                else
                {
                    HideAll();
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

        private bool _isRepeatShow;
        public bool IsRepeatShow
        {
            get => _isRepeatShow;
            set => SetProperty(ref _isRepeatShow, value);
        }

        private bool _isContentShow;
        public bool IsContentShow
        {
            get => _isContentShow;
            set => SetProperty(ref _isContentShow, value);
        }

        private bool _isLoadingShow;
        public bool IsLoadingShow
        {
            get => _isLoadingShow;
            set => SetProperty(ref _isLoadingShow, value);
        }

        public ICommand RepeatCommand => new Command(Load);

        private void HideAll()
        {
            IsContentShow = false;
            IsLoadingShow = false;
            IsRepeatShow = false;
        }

        private async void Load()
        {
            HideAll();

            IsLoadingShow = true;
            try
            {
                var res = await Send();
                Process(res);
            }
            catch
            {
                IsRepeatShow = true;
            }
            finally
            {
                IsLoadingShow = false;
            }
        }

        private async Task<(int Code, string Response)> Send()
        {
            (int Code, string Response) res;
            try
            {
                res = await App.Current.WebClient.SendAsync("GET", new Uri(Config.Uri.ProfileUrl), GetNewToken(), null);
            }
            catch
            {
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
                    var success = Model.FromJson(res.Response);
                    OnModelsJsonChange(success);
                    return;
                default:
                    throw new Exception();
            }
        }

        private void OnModelsJsonChange(bool success)
        {
            if (success)
            {
                IsRepeatShow = false;
                IsContentShow = true;

                if (Model.Image != null)
                    Image = ImageSource.FromUri(Model.Image);
                else
                    Image = ImageSource.FromFile("no_photo");

                Fio = Model.Fio;
                Email = Model.Email;
            }
            else
            {
                IsContentShow = false;
                IsRepeatShow = true;
            }
        }
    }
}
