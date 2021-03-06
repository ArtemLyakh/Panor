﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Panor.Views
{
    public partial class LatestNumbers : Frame
    {
        public LatestNumbers()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MoreCommandProperty = BindableProperty.Create(
            nameof(MoreCommand),
            typeof(ICommand),
            typeof(LatestNumbers)
        );
        public ICommand MoreCommand
        {
            set => SetValue(MoreCommandProperty, value);
            get => (ICommand)GetValue(MoreCommandProperty);
        }

        public static readonly BindableProperty NumbersProperty = BindableProperty.Create(
            nameof(Numbers),
            typeof(List<Models.Numbers.NumberPreview>),
            typeof(LatestNumbers),
            propertyChanged: OnNumberChanged
        );
        public List<Models.Numbers.NumberPreview> Numbers
        {
            set => SetValue(NumbersProperty, value);
            get => (List<Models.Numbers.NumberPreview>)GetValue(NumbersProperty);
        }


        public static readonly BindableProperty ActionsProperty = BindableProperty.Create(
            nameof(Actions),
            typeof(IEnumerable<(string, ICommand)>),
            typeof(LatestNumbers)
        );
        public IEnumerable<(string, ICommand)> Actions
        {
            set => SetValue(ActionsProperty, value);
            get => (IEnumerable<(string, ICommand)>)GetValue(ActionsProperty);
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
            typeof(LatestNumbers)
        );
        public ICommand ReloadCommand
        {
            set => SetValue(ReloadCommandProperty, value);
            get => (ICommand)GetValue(ReloadCommandProperty);
        }


        private static void OnNumberChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var element = (LatestNumbers)bindable;

            element.ElementsStack.BatchBegin();

            element.ElementsStack.Children.Clear();
            var numbers = newValue as IEnumerable<Models.Numbers.NumberPreview>;
            if (numbers != null)
            {
                foreach (var number in numbers)
                {
                    var visual = new Views.NumberPreview();
                    visual.ItemId = number.Id;
                    visual.Title = $"\u2116{number.Number}, {number.Date.Year}";
                    visual.Image = ImageSource.FromUri(number.Image);
                    visual.Name = number.Name;
                    visual.Price = number.Price;
                    visual.CommandList = element.Actions.Select(i => (i.Item1, new Command(() =>
                    {
                        if (i.Item2 != null && i.Item2.CanExecute(number.Id))
                            i.Item2.Execute(number.Id);
                    }) as ICommand)).ToList();

                    element.ElementsStack.Children.Add(visual);
                }

            }

            element.ElementsStack.BatchCommit();
        }

    }
}
