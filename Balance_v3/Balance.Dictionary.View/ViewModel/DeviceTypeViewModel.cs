using Balance.Model.Dictionary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.Dictionary.View.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceTypeViewModel : DeviceCommonViewModel<DeviceType>
    {

        /// <summary>
        /// Список [Типов устройств]
        /// </summary>
        public List<DeviceGadget> DeviceGadgets
        {
            get; set;
        }

        public override DeviceType SelectedCommonModel
        {
            get { return base.SelectedCommonModel; }
            set
            {
                base.SelectedCommonModel = value;
                if (SelectedCommonModel != null)
                {
                    if (SelectedCommonModel.DeviceGadget == null)
                    {
                        SelectedDeviceGadget = null;
                    }
                    else
                    {
                        SelectedDeviceGadget = DeviceGadgets
                                                .Where(x =>
                                                        x.ID == SelectedCommonModel.DeviceGadget.ID &&
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
        private DeviceGadget selectedDeviceGadget;
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        public DeviceGadget SelectedDeviceGadget
        {
            get { return selectedDeviceGadget; }
            set
            {
                selectedDeviceGadget = value;
                OnPropertyChanged(nameof(SelectedDeviceGadget));
            }
        }

        public DeviceTypeViewModel() : base(App.deviceTypeDataService)
        {
            DeviceGadgets = App.deviceGadgetDataService.GetAll().Where(x => x.IsDelete.Equals(false)).ToList();
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<DeviceType>(
                    CommonModels.Where(x =>
                        x.IsDelete.Equals(false) && (
                            x.Name.ToLower().Contains(SearchString) ||
                            x.DeviceGadget.Name.ToLower().Contains(SearchString)
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
