using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class LoadingViewLoader : ContentView
    {
        public LoadingViewLoader()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ViewStateProperty = BindableProperty.Create(
            nameof(ViewState),
            typeof(LoadingContentViewState),
            typeof(LoadingViewLoader),
            default(LoadingContentViewState)
        );
        public LoadingContentViewState ViewState
        {
            set => SetValue(ViewStateProperty, value);
            get => (LoadingContentViewState)GetValue(ViewStateProperty);
        }
    }
}
