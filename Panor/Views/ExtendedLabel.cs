using System;
using Xamarin.Forms;

namespace Panor.Views
{
    public class ExtendedLabel : Label
    {
        public static readonly BindableProperty IsUnderlineProperty = BindableProperty.Create(
            nameof(IsUnderline),
            typeof(bool),
            typeof(ExtendedLabel),
            false
        );
        public bool IsUnderline
        {
            set => SetValue(IsUnderlineProperty, value);
            get => (bool)GetValue(IsUnderlineProperty);
        }

    }
}
