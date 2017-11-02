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

			var latestNumbersModel = new ViewModels.Start.LatestNumbersViewModel();
            var model = new ViewModels.Start.StartPageViewModel()
            {
                Children = {
                    latestNumbersModel
                }
            };

            Model = model;
            latestNumbers.BindingContext = latestNumbersModel;
        }
    }
}
