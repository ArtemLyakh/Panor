using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public class Dropdown : View
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
            
        }
    }
}
