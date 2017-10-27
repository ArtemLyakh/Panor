using System;
using Xamarin.Forms;

namespace Panor.Views
{
    public class BorderButton : Button
    {
        public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
            nameof(Radius),
            typeof(int),
            typeof(BorderButton),
            0
        );
        public int Radius
        {
            set
            {
                if (Device.RuntimePlatform == Device.Android) 
                {
                    SetValue(RadiusProperty, value);
                }
                else 
                {
                    SetValue(BorderRadiusProperty, value);
                }
            }
            get 
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    return (int)GetValue(RadiusProperty);
                }
                else 
                {
                    return (int)GetValue(BorderRadiusProperty);
                }
            }
        }
    }
}
