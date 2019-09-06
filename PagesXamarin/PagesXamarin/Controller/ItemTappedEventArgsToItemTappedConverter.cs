using System;
using System.Globalization;
using Xamarin.Forms;

namespace PagesXamarin.Converters
{
    public class ItemTappedEventArgsToItemTappedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventsArgs = value as ItemTappedEventArgs;
            return eventsArgs?.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventsArgs = value as ItemTappedEventArgs;
            return eventsArgs?.Item;
        }
    }
}