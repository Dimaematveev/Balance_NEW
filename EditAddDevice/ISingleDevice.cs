using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace EditAddDevice
{
    interface ISingleDevice
    {
        /// <summary>
        /// Проверка что все обязательные поля заполнены
        /// </summary>
        List<string> Verification();
        /// <summary>
        /// Получит все возможные параметры для процедуры
        /// </summary>
        List<SqlParameter> GetSqlParameters();
        /// <summary>
        /// Получить UIElement для вставки в окно
        /// </summary>
        /// <returns></returns>
        UIElement GetUIElement();
        /// <summary>
        /// Получить высоту элемента
        /// </summary>
        /// <returns></returns>
        double GetHeight();
    }
}
