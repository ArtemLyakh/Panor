using System;

using Xamarin.Forms;

namespace Panor.Views
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            this.ItemSelected += Handle_ItemSelected;
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null) 
                ((MenuListView)sender).SelectedItem = null;
        }
    }
}

