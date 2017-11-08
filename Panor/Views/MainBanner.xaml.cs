using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class MainBanner : ContentView
    {
        public MainBanner()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ViewStateProperty = BindableProperty.Create(
            nameof(ViewState),
            typeof(LoadingContentViewState),
            typeof(MainBanner),
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
            typeof(MainBanner)
        );
        public ICommand ReloadCommand
        {
            set => SetValue(ReloadCommandProperty, value);
            get => (ICommand)GetValue(ReloadCommandProperty);
        }


    }
}
