using System;

using Xamarin.Forms;

namespace Panor.Pages.Core
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            BindingContext = new ViewModels.Core.MenuPageViewModel();
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
