using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace LostInTime.Converter
{
    public class ReturnParameterConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return parameter;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
