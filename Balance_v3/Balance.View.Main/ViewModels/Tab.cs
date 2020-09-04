using System;
using System.Windows.Controls;

namespace Balance.View.Main.ViewModels
{
    /// <summary>
    /// Вкладка
    /// </summary>
    public class Tab
    {
        /// <summary>
        /// Заглавие Страницы
        /// </summary>
        public string Title
        {
            get; set;
        }

        /// <summary>
        /// Иконка Страницы
        /// </summary>
        public char Icon
        {
            get; set;
        }
        /// <summary>
        /// Функция создания новой Страницы
        /// </summary>
        public Func<Page> OpenNewPage
        {
            get; set;
        }
    }
}
