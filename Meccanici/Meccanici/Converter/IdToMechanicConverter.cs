﻿using Meccanici.Model;
using System;
using System.Windows.Data;

namespace Meccanici.Converter
{
    /// <summary>
    /// Конвертер идентификатора в механика
    /// </summary>
    [ValueConversion(typeof(int), typeof(string))]
    public class IdToMechanicConverter : IValueConverter
    {
        /// <summary>
        /// Преобразует значение. 
        /// </summary>
        /// <param name="value">id механика</param>
        /// <returns>Имя Фамилия. В виде строки</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Person mech = App.mechanicDataService.GetMechanicDetail((int)value);
            return mech.Name + " " + mech.Surname;
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
