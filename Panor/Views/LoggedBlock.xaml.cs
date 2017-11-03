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

        public static readonly BindableProperty ViewStateProperty = BindableProperty.Create(
            nameof(ViewState),
            typeof(LoadingContentViewState),
            typeof(LatestNumbers),
            default(LoadingContentViewState)
        );
        public LoadingContentViewState ViewState
        {
            set => SetValue(ViewStateProperty, value);
            get => (LoadingContentViewState)GetValue(ViewStateProperty);
        }

        public static readonly BindableProperty ReloadCommandProperty = BindableProperty.Create(
            nameof(ReloadCommand),
            typeof(ICommand),
            typeof(LoggedBlock)
        );
        public ICommand ReloadCommand
        {
            set => SetValue(ReloadCommandProperty, value);
            get => (ICommand)GetValue(ReloadCommandProperty);
        }

    }
}
