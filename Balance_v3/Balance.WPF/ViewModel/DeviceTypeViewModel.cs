using Balance.Model;
using Balance.WPF.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Balance.WPF.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceTypeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Динамическая коллекция [Типов устройств]
        /// </summary>
        private ObservableCollection<DeviceType> deviceTypes;

        /// <summary>
        /// Динамическая коллекция [Типов устройств]
        /// </summary>
        public ObservableCollection<DeviceType> DeviceTypes
        {
            get { return deviceTypes; }
            set
            {
                deviceTypes = value;
                OnPropertyChanged(nameof(DeviceTypes));
            }
        }
        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        private ObservableCollection<DeviceType> filteredDeviceTypes;

        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        public ObservableCollection<DeviceType> FilteredDeviceTypes
        {
            get
            {
                return filteredDeviceTypes ?? DeviceTypes;
            }
            set
            {
                filteredDeviceTypes = value;
                SelectedDeviceType = filteredDeviceTypes.FirstOrDefault();
                OnPropertyChanged(nameof(FilteredDeviceTypes));
            }
        }

        /// <summary>
        /// Выбранный [Тип устройства]
        /// </summary>
        private DeviceType selectedDeviceType;
        /// <summary>
        /// Выбранная [Тип устройства]
        /// </summary>
        public DeviceType SelectedDeviceType
        {
            get { return selectedDeviceType; }
            set
            {
                if (SelectedDeviceType != null) 
                    SelectedDeviceType.CancelEdit();
                selectedDeviceType = value;
                OnPropertyChanged(nameof(SelectedDeviceType));
                
                IsEditing = false;
            }
        }
        //TODO:Не понимаю
        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        private object currentEditIcon = '\uE104';
        //TODO:Не понимаю
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
        //TODO: Не понимаю
        /// <summary>
        /// Редактирование анимации??
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
        public ICommand AddDeviceTypeCommand { get; set; }
        /// <summary>
        /// Команда Изменения [Типа устройства]
        /// </summary>
        public ICommand EditDeviceTypeCommand { get; set; }
        /// <summary>
        /// Команда Сохранения [Типа устройства]
        /// </summary>
        public ICommand SaveDeviceTypeCommand { get; set; }
        /// <summary>
        /// Команда Удаления [Типа устройства]
        /// </summary>
        public ICommand DeleteDeviceTypeCommand { get; set; }

        //TODO:Не уверен
        /// <summary>
        /// Поисковая строка
        /// </summary>
        private string searchString;
        //TODO:Не уверен
        /// <summary>
        /// Поисковая строка
        /// </summary>
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredDeviceTypes = new ObservableCollection<DeviceType>(
                    deviceTypes.Where(x => x.Name.ToLower().Contains(SearchString))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
        /// <summary>
        /// Изменение [Типа устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void EditDeviceType(object obj)
        {
            IsEditing = !IsEditing;
            if (!IsEditing)
                SelectedDeviceType.CancelEdit();
            else
                SelectedDeviceType.BeginEdit();
        }
        /// <summary>
        /// Выбрать новый [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void NewDeviceType(object obj)
        {
            SelectedDeviceType = new DeviceType();
            IsEditing = true;
        }
        /// <summary>
        /// Сохранить [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void SaveDeviceType(object obj)
        {
            
            SelectedDeviceType.EndEdit();
            IsEditing = false;
            if (!DeviceTypes.Contains(SelectedDeviceType))
            {
                App.deviceTypeDataService.New(SelectedDeviceType);
                DeviceTypes.Add(SelectedDeviceType);
            }
            else
            {
                App.deviceTypeDataService.Update(SelectedDeviceType);
            }
        }
        /// <summary>
        /// Удалить выбранный [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void DeleteDeviceType(object obj)
        {
            DeviceTypes.Remove(SelectedDeviceType);
            App.deviceTypeDataService.Delete(SelectedDeviceType);
            
            SelectedDeviceType = null;
            IsEditing = false;
        }

        //TODO:не знаю что написать
        public DeviceTypeViewModel()
        {
            
            DeviceTypes = new ObservableCollection<DeviceType>(App.deviceTypeDataService.GetAll());
            AddDeviceTypeCommand = new CustomCommand(NewDeviceType, delegate { return SelectedDeviceType==null || SelectedDeviceType.ID != 0; });
            EditDeviceTypeCommand = new CustomCommand(EditDeviceType, delegate { return SelectedDeviceType != null; });
            SaveDeviceTypeCommand = new CustomCommand(SaveDeviceType, delegate { return IsEditing; });
            DeleteDeviceTypeCommand = new CustomCommand(DeleteDeviceType, delegate { return SelectedDeviceType != null; });
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
