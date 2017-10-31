using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class Loader : ContentView
    {
        public Loader()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
            nameof(IsActive),
            typeof(bool),
            typeof(Loader),
            false
        );
        public bool IsActive
        {
            set => SetValue(IsActiveProperty, value);
            get => (bool)GetValue(IsActiveProperty);
        }
    }
}
