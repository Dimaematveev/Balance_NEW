using Balance.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Balance.ViewModel.Interface
{
    /// <summary>
    /// Интерфейс для Общей ViewModel
    /// </summary>
    public interface ICommonViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        char CurrentEditIcon { get; set; }

        /// <summary>
        /// Анимация кнопок Удаление и сохранения
        /// </summary>
        Action EditingAnimation { get; set; }

        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        bool IsEditing { get; set; }

        /// <summary>
        /// Команда добавления [Типа устройства]
        /// </summary>
        ICommand AddCommand { get; set; }
        /// <summary>
        /// Команда Изменения [Типа устройства]
        /// </summary>
        ICommand EditCommand { get; set; }
        /// <summary>
        /// Команда Сохранения [Типа устройства]
        /// </summary>
        ICommand SaveCommand { get; set; }
        /// <summary>
        /// Команда Удаления [Типа устройства]
        /// </summary>
        ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Поисковая строка
        /// </summary>
        string SearchString { get; set; }
    }
    /// <summary>
    /// Интерфейс для Общей ViewModel
    /// </summary>
    /// <typeparam name="T"> Общая модель из БАзы </typeparam>
    public interface ICommonViewModel<T> : INotifyPropertyChanged where T : CommonModel, new()
    {
        /// <summary>
        /// Динамическая коллекция [Типов устройств]
        /// </summary>
        ObservableCollection<T> CommonModels { get; set; }
        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        ObservableCollection<T> FilteredCommonModels { get; set; }
        /// <summary>
        /// Выбранная [Тип устройства]
        /// </summary>
        T SelectedCommonModel { get; set; }
    }
}
