using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Panor.Views.Templates
{
    public partial class MainPageFreeNumber : ContentView
    {
        public MainPageFreeNumber()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(ImageSource),
            typeof(MainPageFreeNumber)
        );
        public ImageSource Image
        {
            set => SetValue(ImageProperty, value);
            get => (ImageSource)GetValue(ImageProperty);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(MainPageFreeNumber)
        );
        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => (string)GetValue(TitleProperty);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(MainPageFreeNumber)
        );
        public string Text
        {
            set => SetValue(TextProperty, value);
            get => (string)GetValue(TextProperty);
        }

    }
}
