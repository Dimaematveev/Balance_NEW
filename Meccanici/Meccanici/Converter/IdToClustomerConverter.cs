using Meccanici.Model;
using System;
using System.Windows.Data;

namespace Meccanici.Converter
{
    /// <summary>
    /// Конвертер идентификатора в клиента
    /// </summary>
    [ValueConversion(typeof(int), typeof(string))]
    public class IdToCustomerConverter : IValueConverter
    {
        //TODO: mech to cus
        /// <summary>
        /// Преобразует значение. 
        /// </summary>
        /// <param name="value">id клиента</param>
        /// <returns>Имя Фамилия. В виде строки</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Person mech = App.customerDataService.GetCustomerDetail((int)value);
            string res = "";
            if (mech!=null)
            {
                if (!string.IsNullOrWhiteSpace(mech.Name))
                {
                    res += mech.Name + " ";
                }
                if (!string.IsNullOrWhiteSpace(mech.Surname))
                {
                    res += mech.Surname;
                }
            }
            return res;
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
