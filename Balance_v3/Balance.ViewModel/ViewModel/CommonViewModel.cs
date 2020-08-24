using Balance.BL.Interfaces;
using Balance.BL.Utility;
using Balance.DAL.Interface;
using Balance.Model;
using Balance.ViewModel.Interface;
using Balance.ViewModel.InterfaceRealization;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Balance.ViewModel.ViewModel
{
    /// <summary>
    /// View-Model  [Чего-то]
    /// </summary>
    public abstract class CommonViewModel<T> : INotifyPropertyChanged, ICommonViewModel<T>, ICommonViewModel where T : CommonModel, new()
    {
        //TODO:Не могу сформулировать
        protected readonly IDeviceCommonRepository<T> deviceCommonRepository;
        /// <summary>
        /// Динамическая коллекция [Типов устройств] commonModels
        /// </summary>
        private ObservableCollection<T> commonModels;

    
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

  
        public ObservableCollection<T> FilteredCommonModels
        {
            get
            {
                return filteredCommonModels ?? CommonModels;
            }
            set
            {
                filteredCommonModels = value;
                OnPropertyChanged(nameof(FilteredCommonModels));
            }
        }
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
        /// Выбранный [Тип устройства]
        /// </summary>
        private T selectedCommonModel;

        
       
        public virtual T SelectedCommonModel
        {
            get { return selectedCommonModel; }
            set
            {
                if (SelectedCommonModel != null)
                {
                    if (IsEditing)
                    {
                        messageShow.ShowMessage("Вы переходите на другую вкладку. Все изменения будут потеряны. Продолжить?", "Переход", TypeMessage.Question);
                        if (!messageShow.Result)
                        {
                            return;
                        }
                    }
                   
                    SelectedCommonModel.CancelEdit();
                }
                selectedCommonModel = value;
                OnPropertyChanged(nameof(SelectedCommonModel));

                IsEditing = false;
            }
        }


        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        private char currentEditIcon = '\uE104';

   
        public char CurrentEditIcon
        {
            get { return currentEditIcon; }
            set
            {
                currentEditIcon = value;
                OnPropertyChanged(nameof(CurrentEditIcon));
            }
        }

        /// <summary>
        /// Вывод сообщений
        /// </summary>
        private readonly IMessage messageShow;

        
        public Action EditingAnimation { get; set; }
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        private bool isEditing;
       
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
                EditingAnimation?.Invoke();
            }
        }


        public ICommand AddCommand { get; set; }
        
        public ICommand EditCommand { get; set; }
      
        public ICommand SaveCommand { get; set; }
       
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Поисковая строка
        /// </summary>
        protected string searchString;
       
        public abstract string SearchString { get; set; }
        /// <summary>
        /// Изменение [Типа устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void Edit(object obj)
        {
            if (IsEditing)
            {
                messageShow.ShowMessage("Все изменения будут потеряны. Продолжить?", "Отмена", TypeMessage.Question);
                if (!messageShow.Result)
                {
                    return;
                }
                IsEditing = false;
                SelectedCommonModel.CancelEdit();
            }
            else
            {
                IsEditing = true;
                SelectedCommonModel.BeginEdit();
            }
        }
        /// <summary>
        /// Выбрать новый [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void AddNew(object obj)
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
            
            if (!CommonModels.Contains(SelectedCommonModel))
            {
                if (deviceCommonRepository.AddNew(SelectedCommonModel))
                {
                    CommonModels.Add(SelectedCommonModel);
                    messageShow.ShowMessage("Данные добавлены!", "Добавление", TypeMessage.Information);
                }
                else
                {
                    messageShow.ShowMessage(deviceCommonRepository.ErrorText, "Ошибка добавления", TypeMessage.Error);
                    return;
                }
            }
            else
            {
                if (deviceCommonRepository.Update(SelectedCommonModel))
                {
                    messageShow.ShowMessage("Данные обновлены!", "Обновление", TypeMessage.Information);
                }
                else
                {
                    messageShow.ShowMessage(deviceCommonRepository.ErrorText, "Ошибка обновления", TypeMessage.Error);
                    return;
                }

            }
            SelectedCommonModel.EndEdit();
            IsEditing = false;
            SearchString = searchString;
        }
        /// <summary>
        /// Удалить выбранный [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void Delete(object obj)
        {
            messageShow.ShowMessage("Данные будут удалены. Продолжить?", "Удаление", TypeMessage.Question);
            if (!messageShow.Result)
            {
                return;
            }
            if (deviceCommonRepository.Delete(SelectedCommonModel))
            {
                messageShow.ShowMessage("Данные удалены!", "Удаление", TypeMessage.Information);
            }
            else
            {
                messageShow.ShowMessage(deviceCommonRepository.ErrorText, "Ошибка удаления", TypeMessage.Error);
                return;
            }
           
            CommonModels.Remove(SelectedCommonModel);
            SelectedCommonModel = null;
            IsEditing = false;
            SearchString = searchString;
        }


        public CommonViewModel(IDeviceCommonRepository<T> deviceCommonRepository)
        {
            this.deviceCommonRepository = deviceCommonRepository;
            CommonModels = new ObservableCollection<T>(deviceCommonRepository.GetAll());
            AddCommand = new CustomCommand(AddNew, delegate { return SelectedCommonModel == null || SelectedCommonModel.ID != 0; });
            EditCommand = new CustomCommand(Edit, delegate { return SelectedCommonModel != null; });
            SaveCommand = new CustomCommand(Save, delegate { return IsEditing; });
            DeleteCommand = new CustomCommand(Delete, delegate { return SelectedCommonModel != null; });
            messageShow = new MessageShow();
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
