using System;
using System.Globalization;
using Xamarin.Forms;

namespace PagesXamarin.Converters
{
    public class BooleanInverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool valor) return !valor;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventsArgs = value as ItemTappedEventArgs;
            return eventsArgs?.Item;
        }
    }
}