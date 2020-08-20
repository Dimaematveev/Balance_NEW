using System;
using System.Windows.Data;

namespace Meccanici.Converter
{
    /// <summary>
    /// Конвертер даты в день и месяц
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class NiceDateConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует значение. 
        /// </summary>
        /// <param name="value">DataTime </param>
        /// <returns>В строку:день Сокращенное_название_месяца. Большими буквами</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToString("dd\nMMM").ToUpper();
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
