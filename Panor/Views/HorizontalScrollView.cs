using System;
using System.Collections;
using Xamarin.Forms;

namespace Panor.Views
{
    public class HorizontalScrollView : ScrollView
    {
        public HorizontalScrollView()
        {
            this.Orientation = ScrollOrientation.Horizontal;
        }

        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
            nameof(ItemSource),
            typeof(IEnumerable),
            typeof(HorizontalScrollView),
            propertyChanged: (bindable, oldValue, newValue) => Populate(bindable)
        );
        public IEnumerable ItemSource
        {
            set => SetValue(ItemSourceProperty, value);
            get => (IEnumerable)GetValue(ItemSourceProperty);
        }

        public static readonly BindableProperty DataTemplateProperty = BindableProperty.Create(
            nameof(DataTemplate),
            typeof(DataTemplate),
            typeof(HorizontalScrollView),
            propertyChanged: (bindable, oldValue, newValue) => Populate(bindable)
        );
        public DataTemplate DataTemplate
        {
            set => SetValue(DataTemplateProperty, value);
            get => (DataTemplate)GetValue(DataTemplateProperty);
        }

        public double? Spacing { get; set; } 
        public double? ContentPadding { get; set; }


        static void Populate(BindableObject bindable)
        {
            var element = (HorizontalScrollView)bindable;

			element.Content = null;
            if (element.DataTemplate == null || element.ItemSource == null) return;

            var stack = new StackLayout() 
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = element.Spacing.HasValue ? element.Spacing.Value : 10,
                Padding = new Thickness(element.ContentPadding.HasValue ? element.ContentPadding.Value : 0, 0)
            };

            foreach (var item in element.ItemSource)
            {
                var content = (View)element.DataTemplate.CreateContent();
                content.BindingContext = item;

                stack.Children.Add(content);
            }

            element.Content = stack;
        }

    }
}
