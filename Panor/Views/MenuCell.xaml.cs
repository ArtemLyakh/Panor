using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class MenuCell : ViewCell
    {
        public MenuCell()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(ImageSource),
            typeof(MenuCell)
        );
        public ImageSource Image
        {
            set { SetValue(ImageProperty, value); }
            get { return (ImageSource)GetValue(ImageProperty); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(MenuCell)
        );
        public string Text
        {
            set { SetValue(TextProperty, value); }
            get { return (string)GetValue(TextProperty); }
        }

        public static readonly BindableProperty NumberProperty = BindableProperty.Create(
            nameof(Number),
            typeof(int),
            typeof(MenuCell),
            0
        );
        public int Number
        {
            set { SetValue(NumberProperty, value); }
            get { return (int)GetValue(NumberProperty); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(MenuCell)
        );
        public ICommand Command
        {
            set { SetValue(CommandProperty, value); }
            get { return (ICommand)GetValue(CommandProperty); }
        }

    }
}
