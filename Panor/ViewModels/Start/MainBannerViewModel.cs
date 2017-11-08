using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.ViewModels.Start
{
    public class MainBannerViewModel : BaseViewModel
    {
        public MainBannerViewModel()
        {
            Load();
        }

        private IList<Models.Banners.MainBanner> _data = new List<Models.Banners.MainBanner>()
        {
            new Models.Banners.MainBanner()
        };
        public IList<Models.Banners.MainBanner> Data 
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private Views.LoadingContentViewState _viewState = Views.LoadingContentViewState.Content;
        public Views.LoadingContentViewState ViewState
        {
            get => _viewState;
            set => SetProperty(ref _viewState, value);
        }

        public ICommand ReloadCommand => new Command(Load);


        private async void Load()
        {
            ViewState = Views.LoadingContentViewState.Loading;

            List<Models.Banners.MainBanner> res;
            try
            {
                res = await App.Current.Api.GetMainBanner(GetNewToken());
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

            Data = res;
            ViewState = Views.LoadingContentViewState.Content;
        }

    }
}