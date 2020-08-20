using System;
using System.Windows.Data;

namespace Meccanici.Converter
{
    /// <summary>
    /// Конвертер даты в день
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class NoHoursDateConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует значение. 
        /// </summary>
        /// <param name="value">DataTime </param>
        /// <returns>День</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToString("d").ToUpper();
        }
        /// <summary>
        ///  Исключение
        /// </summary>
        /// <returns>Исключение</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
