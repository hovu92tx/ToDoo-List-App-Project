using System.Globalization;
using System;
namespace ToDoo.Converter
{
    public class FilterTextConverter : IValueConverter
    {
        
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "All" : "Active";
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
