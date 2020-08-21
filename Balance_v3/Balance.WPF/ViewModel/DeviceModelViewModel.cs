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
    public class DeviceModelViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Динамическая коллекция [Типов устройств]
        /// </summary>
        private ObservableCollection<DeviceModel> deviceModels;

        /// <summary>
        /// Динамическая коллекция [Типов устройств]
        /// </summary>
        public ObservableCollection<DeviceModel> DeviceModels
        {
            get { return deviceModels; }
            set
            {
                deviceModels = value;
                OnPropertyChanged(nameof(DeviceModels));
            }
        }
        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        private ObservableCollection<DeviceModel> filteredDeviceModels;

        /// <summary>
        /// Динамическая коллекция отфильтрованных [Типов устройств]
        /// </summary>
        public ObservableCollection<DeviceModel> FilteredDeviceModels
        {
            get
            {
                return filteredDeviceModels ?? DeviceModels;
            }
            set
            {
                filteredDeviceModels = value;
                SelectedDeviceModel = filteredDeviceModels.FirstOrDefault();
                OnPropertyChanged(nameof(FilteredDeviceModels));
            }
        }

        /// <summary>
        /// Выбранный [Тип устройства]
        /// </summary>
        private DeviceModel selectedDeviceModel;
        /// <summary>
        /// Выбранная [Тип устройства]
        /// </summary>
        public DeviceModel SelectedDeviceModel
        {
            get { return selectedDeviceModel; }
            set
            {
                if (SelectedDeviceModel != null)
                    SelectedDeviceModel.CancelEdit();
                selectedDeviceModel = value;
                OnPropertyChanged(nameof(SelectedDeviceModel));

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
        public ICommand AddDeviceModelCommand { get; set; }
        /// <summary>
        /// Команда Изменения [Типа устройства]
        /// </summary>
        public ICommand EditDeviceModelCommand { get; set; }
        /// <summary>
        /// Команда Сохранения [Типа устройства]
        /// </summary>
        public ICommand SaveDeviceModelCommand { get; set; }
        /// <summary>
        /// Команда Удаления [Типа устройства]
        /// </summary>
        public ICommand DeleteDeviceModelCommand { get; set; }

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
                FilteredDeviceModels = new ObservableCollection<DeviceModel>(
                    deviceModels.Where(x => x.Name.ToLower().Contains(SearchString))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
        /// <summary>
        /// Изменение [Типа устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void EditDeviceModel(object obj)
        {
            IsEditing = !IsEditing;
            if (!IsEditing)
                SelectedDeviceModel.CancelEdit();
            else
                SelectedDeviceModel.BeginEdit();
        }
        /// <summary>
        /// Выбрать новый [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void NewDeviceModel(object obj)
        {
            SelectedDeviceModel = new DeviceModel();
            IsEditing = true;
        }
        /// <summary>
        /// Сохранить [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void SaveDeviceModel(object obj)
        {

            SelectedDeviceModel.EndEdit();
            IsEditing = false;
            if (!DeviceModels.Contains(SelectedDeviceModel))
            {
                App.deviceModelRepository.New(SelectedDeviceModel);
                DeviceModels.Add(SelectedDeviceModel);
            }
        }
        /// <summary>
        /// Удалить выбранный [Тип устройства]
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void DeleteDeviceModel(object obj)
        {
            App.deviceModelRepository.Delete(SelectedDeviceModel);
            DeviceModels.Remove(SelectedDeviceModel);
            SelectedDeviceModel = null;
            IsEditing = false;
        }

        //TODO:не знаю что написать
        public DeviceModelViewModel()
        {

            DeviceModels = new ObservableCollection<DeviceModel>(App.deviceModelRepository.GetAll());
            AddDeviceModelCommand = new CustomCommand(NewDeviceModel, delegate { return SelectedDeviceModel == null || SelectedDeviceModel.ID != 0; });
            EditDeviceModelCommand = new CustomCommand(EditDeviceModel, delegate { return SelectedDeviceModel != null; });
            SaveDeviceModelCommand = new CustomCommand(SaveDeviceModel, delegate { return IsEditing; });
            DeleteDeviceModelCommand = new CustomCommand(DeleteDeviceModel, delegate { return SelectedDeviceModel != null; });
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
