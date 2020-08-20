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
        /// Динамическая коллекция Машин
        /// </summary>
        private ObservableCollection<DeviceType> deviceTypes;

        /// <summary>
        /// Динамическая коллекция Машин
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
        /// Динамическая коллекция отфильтрованных Машин
        /// </summary>
        private ObservableCollection<DeviceType> filteredDeviceTypes;

        /// <summary>
        /// Динамическая коллекция отфильтрованных Машин
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
        /// Выбранная машина
        /// </summary>
        private DeviceType selectedDeviceType;
        /// <summary>
        /// Выбранная машина
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
        private string currentEditIcon = "Edit";
        //TODO:Не понимаю
        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        public string CurrentEditIcon
        {
            get { return currentEditIcon; }
            set
            {
                currentEditIcon = value;
                OnPropertyChanged("CurrentEditIcon");
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
                    CurrentEditIcon = "";
                else
                    CurrentEditIcon = "";
                OnPropertyChanged(nameof(IsEditing));
                editingAnimation?.Invoke();
            }
        }



        /// <summary>
        /// Команда добавления Машины
        /// </summary>
        public ICommand AddDeviceTypeCommand { get; set; }
        /// <summary>
        /// Команда Изменения Машины
        /// </summary>
        public ICommand EditDeviceTypeCommand { get; set; }
        /// <summary>
        /// Команда Сохранения Машины
        /// </summary>
        public ICommand SaveDeviceTypeCommand { get; set; }
        /// <summary>
        /// Команда Удаления Машины
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
        /// Изменение Клиента
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
        /// Выбрать новую машину
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void NewDeviceType(object obj)
        {
            SelectedDeviceType = new DeviceType();
            IsEditing = true;
        }
        /// <summary>
        /// Сохранить машину
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
        }
        /// <summary>
        /// Удалить выбранную машину
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void DeleteDeviceType(object obj)
        {
            App.deviceTypeDataService.Delete(SelectedDeviceType);
            DeviceTypes.Remove(SelectedDeviceType);
            SelectedDeviceType = null;
            IsEditing = false;
        }

        //TODO:не знаю что написать
        public DeviceTypeViewModel()
        {
            
            DeviceTypes = new ObservableCollection<DeviceType>(App.deviceTypeDataService.GetAll());
            AddDeviceTypeCommand = new CustomCommand(NewDeviceType, delegate { return true; });
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
