using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

namespace EditAddDevice
{
    interface ISingleDevice
    {
        /// <summary>
        /// Проверка что все обязательные поля заполнены
        /// </summary>
        bool Verification();
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
