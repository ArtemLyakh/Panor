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
            BindingContext = this;
        }

        public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
            nameof(Command),
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
