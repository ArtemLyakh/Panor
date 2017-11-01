using System;

using Xamarin.Forms;

namespace Panor.Pages.Core
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Core.MenuPageViewModel();
            loggedBlock.BindingContext = new ViewModels.Core.LoggedBlockViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            App.Current.CloseMenu();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            App.Current.CloseMenu();
        }
    }
}
