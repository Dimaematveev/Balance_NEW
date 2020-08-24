namespace Balance.BL.Interfaces
{
    public abstract class IMessage
    {
        public abstract void ShowMessage(string message, TypeMessage typeMessage);
        public bool Result { get; set; }
        public void ShowMessage(string message)
        {
            ShowMessage(message, TypeMessage.None);
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
