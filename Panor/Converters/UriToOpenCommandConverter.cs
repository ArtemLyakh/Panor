using System;
using System.Globalization;
using Xamarin.Forms;

namespace Panor.Converters
{
    public class UriToOpenCommandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = value as Uri;

            if (uri == null) return null;

            return new Command(() => Device.OpenUri(uri));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
