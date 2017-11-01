using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class TitledEntry : ContentView
    {
        public TitledEntry()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(TitledEntry)
        );
        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => (string)GetValue(TitleProperty);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(TitledEntry),
            defaultBindingMode: BindingMode.TwoWay
        );
        public string Text
        {
            set => SetValue(TextProperty, value);
            get => (string)GetValue(TextProperty);
        }

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
            nameof(IsPassword),
            typeof(bool),
            typeof(TitledEntry),
            false
        );
        public bool IsPassword
        {
            set => SetValue(IsPasswordProperty, value);
            get => (bool)GetValue(IsPasswordProperty);
        }

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
            nameof(Keyboard),
            typeof(Keyboard),
            typeof(TitledEntry),
            default(Keyboard)
        );
        public Keyboard Keyboard
        {
            set => SetValue(KeyboardProperty, value);
            get => (Keyboard)GetValue(KeyboardProperty);
        }
    }
}
