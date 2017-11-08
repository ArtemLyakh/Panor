using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class FreeNumbers : ContentView
    {
        public FreeNumbers()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ViewStateProperty = BindableProperty.Create(
            nameof(ViewState),
            typeof(LoadingContentViewState),
            typeof(FreeNumbers),
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
            typeof(FreeNumbers)
        );
        public ICommand ReloadCommand
        {
            set => SetValue(ReloadCommandProperty, value);
            get => (ICommand)GetValue(ReloadCommandProperty);
        }

        public static readonly BindableProperty MoreCommandProperty = BindableProperty.Create(
            nameof(MoreCommand),
            typeof(ICommand),
            typeof(FreeNumbers)
        );
        public ICommand MoreCommand
        {
            set => SetValue(MoreCommandProperty, value);
            get => (ICommand)GetValue(MoreCommandProperty);
        }


        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
            nameof(ItemSource),
            typeof(IEnumerable),
            typeof(FreeNumbers)
        );
        public IEnumerable ItemSource
        {
            set => SetValue(ItemSourceProperty, value);
            get => (IEnumerable)GetValue(ItemSourceProperty);
        }



    }
}
