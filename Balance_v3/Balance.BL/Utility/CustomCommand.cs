using System;
using System.Windows.Input;

namespace Balance.BL.Utility
{
    /// <summary>
    /// Класс для действий, Реализует ICommand.
    /// </summary>
    public class CustomCommand : ICommand
    {
        /// <summary>
        /// Выполняемое действие
        /// </summary>
        private readonly Action<object> execute;
        /// <summary>
        /// Показывает может ли выполнится действие
        /// </summary>
        private readonly Predicate<object> canExecute;

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            bool b = canExecute == null || canExecute(parameter);
            return b;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
