using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class LoggedBlock : ContentView
    {
        public LoggedBlock()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            nameof(Name),
            typeof(string),
            typeof(LoggedBlock),
            defaultBindingMode: BindingMode.TwoWay
        );
        public string Name
        {
            set => SetValue(NameProperty, value);
            get => (string)GetValue(NameProperty);
        }

        public static readonly BindableProperty EmailProperty = BindableProperty.Create(
            nameof(Email),
            typeof(string),
            typeof(LoggedBlock),
            defaultBindingMode: BindingMode.TwoWay
        );
        public string Email
        {
            set => SetValue(EmailProperty, value);
            get => (string)GetValue(EmailProperty);
        }

        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(ImageSource),
            typeof(LoggedBlock),
            defaultBindingMode: BindingMode.TwoWay
        );
        public ImageSource Image
        {
            set => SetValue(ImageProperty, value);
            get => (ImageSource)GetValue(ImageProperty);
        }

        public static readonly BindableProperty IsLoadingShowProperty = BindableProperty.Create(
            nameof(IsLoadingShow),
            typeof(bool),
            typeof(LoggedBlock),
            true
        );
        public bool IsLoadingShow
        {
            set => SetValue(IsLoadingShowProperty, value);
            get => (bool)GetValue(IsLoadingShowProperty);
        }

        public static readonly BindableProperty IsContentShowProperty = BindableProperty.Create(
            nameof(IsContentShow),
            typeof(bool),
            typeof(LoggedBlock),
            false
        );
        public bool IsContentShow 
        {
            set => SetValue(IsContentShowProperty, value);
            get => (bool)GetValue(IsContentShowProperty);
        }

        public static readonly BindableProperty IsReloadShowProperty = BindableProperty.Create(
            nameof(IsReloadShow),
            typeof(bool),
            typeof(LatestNumbers),
            false
        );
        public bool IsReloadShow
        {
            set => SetValue(IsReloadShowProperty, value);
            get => (bool)GetValue(IsReloadShowProperty);
        }

        public static readonly BindableProperty RepeatCommandProperty = BindableProperty.Create(
            nameof(RepeatCommand),
            typeof(ICommand),
            typeof(LoggedBlock)
        );
        public ICommand RepeatCommand
        {
            set => SetValue(RepeatCommandProperty, value);
            get => (ICommand)GetValue(RepeatCommandProperty);
        }

    }
}
