using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class LoggedBlock : ContentView
    {
        public LoggedBlock()
        {
            InitializeComponent();
            Image = ImageSource.FromFile("druzd");

            BindingContext = this;
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(LoggedBlock)
        );

        public string Name
        {
            set { SetValue(NameProperty, value); }
            get { return (string)GetValue(NameProperty); }
        }

        public static readonly BindableProperty EmailProperty = BindableProperty.Create(
            nameof(Email),
            typeof(string),
            typeof(LoggedBlock)
        );

        public string Email
        {
            set { SetValue(EmailProperty, value); }
            get { return (string)GetValue(EmailProperty); }
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(ImageSource),
            typeof(LoggedBlock)
        );

        public ImageSource Image
        {
            set { SetValue(ImageProperty, value); }
            get { return (ImageSource)GetValue(ImageProperty); }
        }



    }
}
