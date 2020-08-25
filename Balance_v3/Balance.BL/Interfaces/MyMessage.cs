namespace Balance.BL.Interfaces
{
    /// <summary>
    /// Абстрактный класс вывода сообщения
    /// </summary>
    public abstract class MyMessage
    {
        /// <summary>
        /// Вывести сообщение на экран
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="header">Заголовок</param>
        /// <param name="typeMessage">Тип сообщения</param>
        public abstract void ShowMessage(string message, string header, TypeMessage typeMessage);
        /// <summary>
        /// Результат сообщения
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// Вывести сообщение на экран c пустым заголовком и без значка
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void ShowMessage(string message)
        {
            ShowMessage(message, null, TypeMessage.None);
        }
        /// <summary>
        /// Вывести сообщение на экран без значка
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="header">Заголовок</param>
        public void ShowMessage(string message, string header)
        {
            ShowMessage(message, header, TypeMessage.None);
        }
        /// <summary>
        /// Вывести сообщение на экран с заголовком соответствующему типу сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="typeMessage">Тип сообщения</param>
        public void ShowMessage(string message, TypeMessage typeMessage)
        {
            ShowMessage(message, null, typeMessage);
        }

    }
    public enum TypeMessage
    {
        /// <summary>
        /// Значок - Не отображается
        /// Сообщение - Кнопка ОК
        /// </summary>
        None = 0,
        /// <summary>
        /// Значок - Не Крестик
        /// Сообщение - Кнопка ОК
        /// </summary>
        Error = 16,
        /// <summary>
        /// Значок - Вопроса
        /// Сообщение - Кнопка Yes/No
        /// </summary>
        Question = 32,
        /// <summary>
        /// Значок - Восклицательный знак
        /// Сообщение - Кнопка ОК
        /// </summary>
        Warning = 48,
        /// <summary>
        /// Значок - маленькая 'i'
        /// Сообщение - Кнопка ОК
        /// </summary>
        Information = 64

    }
}
