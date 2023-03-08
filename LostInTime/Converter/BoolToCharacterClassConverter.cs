using System;
using System.Globalization;
using Avalonia.Data.Converters;
using LostInTime.Models;

namespace LostInTime.Converter
{
    public class BoolToCharacterClassConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is CharacterClass characterClass && parameter is CharacterClass parameterClass)
            {
                return characterClass == parameterClass;
            }

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b && parameter is CharacterClass parameterClass)
            {
                return b ? parameterClass : null;
            }

            return null;
        }
    }
}
