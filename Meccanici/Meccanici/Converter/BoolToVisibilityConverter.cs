using System;
using System.Windows;
using System.Windows.Data;

namespace Meccanici.Converter
{
    /// <summary>
    /// Конвертер Bool в видимость
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует значение.
        /// </summary>
        /// <param name="value">true/false значение</param>
        /// <returns>Если true возвращается Visible, иначе - Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        /// <summary>
        /// Преобразует значение обратно. 
        /// </summary>
        /// <param name="value">Значение Visibility </param>
        /// <returns>Если Visibility.Visible возвращается true, иначе - false</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
