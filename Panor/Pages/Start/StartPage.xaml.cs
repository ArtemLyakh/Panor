using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Panor.Pages.Start
{
    public partial class StartPage : BasePage
    {
        public StartPage()
        {
            InitializeComponent();

            latestNumbers.BindingContext = new ViewModels.Start.LatestNumbersViewModel();
            mainBanner.BindingContext = new ViewModels.Start.MainBannerViewModel();

            Model = new ViewModels.Start.StartPageViewModel()
            {
                Children = {
                    (ViewModels.BaseViewModel)latestNumbers.BindingContext,
                    (ViewModels.BaseViewModel)mainBanner.BindingContext
                }
            };
        }
    }
}
