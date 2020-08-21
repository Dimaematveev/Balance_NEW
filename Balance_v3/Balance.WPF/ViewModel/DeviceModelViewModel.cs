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
    public class DeviceModelViewModel : DeviceCommonViewModel<DeviceModel>
    {
        /// <summary>
        /// Список [Типов устройств]
        /// </summary>
        public List<DeviceType> DeviceTypes
        {
            get;set;
        }

        public override DeviceModel SelectedCommonModel
        {
            get { return base.SelectedCommonModel; }
            set
            {
                base.SelectedCommonModel = value;
                if (SelectedCommonModel != null)
                {
                    selectedDeviceType = DeviceTypes.Where(x => x.ID == SelectedCommonModel.DeviceTypeID).FirstOrDefault();
                }
               
            }
        }

        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        private DeviceType selectedDeviceType;
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        public DeviceType SelectedDeviceType
        {
            get { return selectedDeviceType; }
            set
            {
                selectedDeviceType = value;
                OnPropertyChanged(nameof(SelectedDeviceType));
            }
        }

        public DeviceModelViewModel() : base(App.deviceModelRepository)
        {
            DeviceTypes= App.deviceTypeDataService.GetAll();
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<DeviceModel>(
                    CommonModels.Where(x => 
                        x.Name.ToLower().Contains(SearchString) ||
                        x.DeviceType.Name.ToLower().Contains(SearchString)
                        )
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
