using System;
using Xamarin.Forms;

namespace Panor.Pages
{
    public class BasePage : ContentPage
    {
        protected ViewModels.Base Model
        {
            get => (ViewModels.Base)BindingContext;
            set => BindingContext = value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Model?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Model?.OnDisappearing();
        }

    }
}
