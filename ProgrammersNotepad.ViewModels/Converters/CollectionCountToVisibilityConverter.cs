using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ProgrammersNotepad.ViewModels.Converters
{
    public class CollectionCountToVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int length)
            {
                return length == 0 ? Visibility.Hidden : Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}