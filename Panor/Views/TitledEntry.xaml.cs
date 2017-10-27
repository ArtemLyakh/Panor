﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class TitledEntry : ContentView
    {
        public TitledEntry()
        {
            InitializeComponent();
            BindingContext = this;
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
            typeof(TitledEntry)
        );

        public string Text
        {
            set => SetValue(TextProperty, value);
            get => (string)GetValue(TextProperty);
        }

    }
}
