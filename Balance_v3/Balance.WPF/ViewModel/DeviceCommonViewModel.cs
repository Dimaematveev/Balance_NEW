using Balance.DAL.Interface;
using Balance.Model;
using Balance.Dictionary.WPF.Utility;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Balance.Dictionary.WPF.ViewModel
{
    /// <summary>
    /// View-Model  [Чего-то]
    /// </summary>
    public abstract class DeviceCommonViewModel<T> : INotifyPropertyChanged where T : CommonModel, new()
    {
        private readonly IDeviceCommonRepository<T> deviceCommonRepository;
        /// <summary>
        /// Динамическая коллекция [Типов устройств] commonModels
        /// </summary>
        private ObservableCollection<T> commonModels;

        /// <summary>
        /// Динамическая коллекция [Типов устройств]
        /// </summary>
        public ObservableCollection<T> CommonModels
        {
            get { return commonModels; }
            set
            {
                commonModels = value;
                OnPropertyChanged(nameof(CommonModels));
            }
        }
        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        private ObservableCollection<T> filteredCommonModels;

        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        public ObservableCollection<T> FilteredCommonModels
        {
            get
            {
                return filteredCommonModels ?? CommonModels;
            }
            set
            {
                filteredCommonModels = value;
                SelectedCommonModel = filteredCommonModels.FirstOrDefault();
                OnPropertyChanged(nameof(FilteredCommonModels));
            }
        }

        /// <summary>
        /// Выбранный [Тип устройства]
        /// </summary>
        private T selectedCommonModel;

        /// <summary>
        /// Получить строку для сравнения в фильтре
        /// </summary>
        /// <param name="obj">Объект преобразуемый в строку</param>
        /// <returns>Полученная строка</returns>
        protected string GetStringForComparison(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            return obj.ToString().ToLower();
        }
        /// <summary>
        /// Выбранная [Тип устройства]
        /// </summary>
        public virtual T SelectedCommonModel
        {
            get { return selectedCommonModel; }
            set
            {
                if (SelectedCommonModel != null)
                    SelectedCommonModel.CancelEdit();
                selectedCommonModel = value;
                OnPropertyChanged(nameof(SelectedCommonModel));

                IsEditing = false;
            }
        }
        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        private object currentEditIcon = '\uE104';

        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        public object CurrentEditIcon
        {
            get { return currentEditIcon; }
            set
            {
                currentEditIcon = value;
                OnPropertyChanged(nameof(CurrentEditIcon));
            }
        }
        /// <summary>
        /// Анимация кнопок Удаление и сохранения
        /// </summary>
        public Action editingAnimation;
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        private bool isEditing;
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                if (IsEditing)
                    CurrentEditIcon = '\uE106';
                else
                    CurrentEditIcon = '\uE104';
                OnPropertyChanged(nameof(IsEditing));
                editingAnimation?.Invoke();
            }
        }



        /// <summary>
        /// Команда добавления [Типа устройства]
        /// </summary>
        public ICommand AddCommand { get; set; }
        /// <summary>
        /// Команда Изменения [Типа устройства]
        /// </summary>
        public ICommand EditCommand { get; set; }
        /// <summary>
        /// Команда Сохранения [Типа устройства]
        /// </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary>
        /// Команда Удаления [Типа устройства]
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Поисковая строка
        /// </summary>
        protected string searchString;
        /// <summary>
        /// Поисковая строка
        /// </summary>
        public abstract string SearchString { get; set; }
        /// <summary>
        /// Изменение [Типа устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void Edit(object obj)
        {
            IsEditing = !IsEditing;
            if (!IsEditing)
                SelectedCommonModel.CancelEdit();
            else
                SelectedCommonModel.BeginEdit();
        }
        /// <summary>
        /// Выбрать новый [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void New(object obj)
        {
            SelectedCommonModel = new T();
            IsEditing = true;
        }
        /// <summary>
        /// Сохранить [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void Save(object obj)
        {

            SelectedCommonModel.EndEdit();
            IsEditing = false;
            if (!CommonModels.Contains(SelectedCommonModel))
            {
                deviceCommonRepository.New(SelectedCommonModel);
                CommonModels.Add(SelectedCommonModel);
            }
            else
            {
                deviceCommonRepository.Update(SelectedCommonModel);
            }
            SearchString = searchString;
        }
        /// <summary>
        /// Удалить выбранный [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void Delete(object obj)
        {
            deviceCommonRepository.Delete(SelectedCommonModel);
            CommonModels.Remove(SelectedCommonModel);
            SelectedCommonModel = null;
            IsEditing = false;
            SearchString = searchString;
        }

      
        public DeviceCommonViewModel(IDeviceCommonRepository<T> deviceCommonRepository)
        {
            this.deviceCommonRepository = deviceCommonRepository;
            CommonModels = new ObservableCollection<T>(deviceCommonRepository.GetAll());
            AddCommand = new CustomCommand(New, delegate { return SelectedCommonModel == null || SelectedCommonModel.ID != 0; });
            EditCommand = new CustomCommand(Edit, delegate { return SelectedCommonModel != null; });
            SaveCommand = new CustomCommand(Save, delegate { return IsEditing; });
            DeleteCommand = new CustomCommand(Delete, delegate { return SelectedCommonModel != null; });
            IsEditing = false;

        }


        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="prop">Изменившееся свойство </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
