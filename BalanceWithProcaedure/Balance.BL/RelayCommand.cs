using System;
using System.Windows.Input;

namespace Balance.BL
{
    /// <summary>
    /// Класс для действий, Реализует ICommand.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Выполняемое действие
        /// </summary>
        private readonly Action<object> execute;
        /// <summary>
        /// Показывает может ли выполнится действие
        /// </summary>
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
