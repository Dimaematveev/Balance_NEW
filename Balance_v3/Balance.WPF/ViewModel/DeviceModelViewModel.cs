using Balance.Model.Dictionary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
                    if (SelectedCommonModel.DeviceType == null)
                    {
                        SelectedDeviceType = null;
                    }
                    else
                    {
                        SelectedDeviceType = DeviceTypes
                                                .Where(x =>
                                                        x.ID == SelectedCommonModel.DeviceType.ID &&
                                                        x.IsDelete.Equals(false)
                                                      )
                                                .FirstOrDefault();
                    }
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
            DeviceTypes = App.deviceTypeDataService.GetAll().Where(x => x.IsDelete.Equals(false)).ToList();
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<DeviceModel>(
                    CommonModels.Where(x => 
                        x.IsDelete.Equals(false) && (
                            x.Name.ToLower().Contains(SearchString) ||
                            x.DeviceType.Name.ToLower().Contains(SearchString) 
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
