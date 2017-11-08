using System;
using System.Globalization;
using Xamarin.Forms;

namespace Panor.Converters
{
    public class UriToImageSourceConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = value as Uri;

            if (uri == null) return null;

            return ImageSource.FromUri(uri);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var source = value as UriImageSource;

            if (source == null) return null;

            return source.Uri;
        }
    }
}
