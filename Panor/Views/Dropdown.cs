using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public class Dropdown : ContentView
    {
        public static readonly BindableProperty CommandsProperty = BindableProperty.Create(
            nameof(Commands),
            typeof(IList<(string, ICommand)>),
            typeof(Dropdown)
        );
        public IList<(string Text, ICommand Command)> Commands
        {
            set => SetValue(CommandsProperty, value);
            get => (IList<(string, ICommand)>)GetValue(CommandsProperty);
        }


        public Dropdown()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                CreateIOS();
            }
        }

        private void CreateIOS()
        {
            var img = new Image()
            {
                Source = ImageSource.FromFile("dropdown_btn"),
                Aspect = Aspect.Fill
            };
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += Tgr_Tapped;

            img.GestureRecognizers.Add(tgr);

            Content = img;
        }

        async void Tgr_Tapped(object sender, EventArgs e)
        {
            if (Commands == null) return;

            var res = await App.Current.MainPage.DisplayActionSheet(null, "Отмена", null, Commands.Select(i => i.Text).ToArray());

            var selectedCommand = Commands.FirstOrDefault(i => i.Text == res).Command;
            if (selectedCommand != null && selectedCommand.CanExecute(null))
            {
                selectedCommand.Execute(null);
            }
        }
    }
}
