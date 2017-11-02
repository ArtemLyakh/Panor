using System;
using System.Collections.Generic;
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
            typeof(IEnumerable<Models.Numbers.NumberPreview>),
            typeof(LatestNumbers),
            propertyChanged: OnNumberChanged
        );
        public IEnumerable<Models.Numbers.NumberPreview> Numbers
        {
            set => SetValue(NumbersProperty, value);
            get => (IEnumerable<Models.Numbers.NumberPreview>)GetValue(NumbersProperty);
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
                    visual.CommandList = element.Actions;

                    element.ElementsStack.Children.Add(visual);
                }

            }

            element.ElementsStack.BatchCommit();
        }

    }
}
