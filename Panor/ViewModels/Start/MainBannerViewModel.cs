using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Panor.ViewModels.Start
{
    public class MainBannerViewModel : BaseViewModel
    {
        public MainBannerViewModel()
        {
        }

        public IList<Models.Banners.MainBanner> Data { get; set; } = new List<Models.Banners.MainBanner>()
        {
            new Models.Banners.MainBanner()
            {
                Image = new Uri("http://panor.ru/bitrix/templates/panor2016/img/slider/slide-bg03.jpg"),
                Url = new Uri("http://panor.ru")
            },
            new Models.Banners.MainBanner()
            {
                Image = new Uri("http://panor.ru/bitrix/templates/panor2016/img/slider/slide-bg03.jpg"),
                Url = new Uri("http://panor.ru")
            },
            new Models.Banners.MainBanner()
            {
                Image = new Uri("https://www.google.ru/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"),
                Url = new Uri("http://panor.ru")
            },
            new Models.Banners.MainBanner()
            {
                Image = new Uri("http://panor.ru/bitrix/templates/panor2016/img/slider/slide-bg03.jpg"),
                Url = new Uri("http://panor.ru")
            }
        };

        private Views.LoadingContentViewState _viewState = Views.LoadingContentViewState.Content;
        public Views.LoadingContentViewState ViewState
        {
            get => _viewState;
            set => SetProperty(ref _viewState, value);
        }

    }
}
