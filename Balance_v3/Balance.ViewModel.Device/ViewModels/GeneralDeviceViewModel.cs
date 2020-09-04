using Balance.DAL.Interface;
using Balance.Model.Devices;
using Balance.Model.Dictionaries;
using Balance.ViewModel.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.ViewModel.Device.ViewModels
{
    public class GeneralDeviceViewModel : MyCommonViewModel<GeneralDevice>
    {
        /// <summary>
        /// Хранилище Моделей устройств
        /// </summary>
        private readonly IDeviceCommonRepository<DeviceModel> deviceModelRepository;
        /// <summary>
        /// Хранилище местоположений
        /// </summary>
        private readonly IDeviceCommonRepository<Location> locationRepository;
        /// <summary>
        /// Список [Типов устройств]
        /// </summary>
        public List<DeviceModel> DeviceModels
        {
            get; set;
        }
        /// <summary>
        /// Список [Типов устройств]
        /// </summary>
        public List<Location> Locations
        {
            get; set;
        }

        public override GeneralDevice SelectedCommonModel
        {
            get { return base.SelectedCommonModel; }
            set
            {
                base.SelectedCommonModel = value;


                if (SelectedCommonModel != null)
                {
                    if (SelectedCommonModel.DeviceModel == null)
                    {
                        selectedDeviceModel = null;
                    }
                    else
                    {
                        SelectedDeviceModel = DeviceModels
                                                .Where(x =>
                                                        x.ID == SelectedCommonModel.DeviceModel.ID &&
                                                        x.IsDelete.Equals(false)
                                                      )
                                                .FirstOrDefault();
                    }
                    if (SelectedCommonModel.Location == null)
                    {
                        selectedLocation = null;
                    }
                    else
                    {
                        SelectedLocation = Locations
                                                .Where(x =>
                                                        x.ID == SelectedCommonModel.Location.ID &&
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
        private DeviceModel selectedDeviceModel;
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        public DeviceModel SelectedDeviceModel
        {
            get { return selectedDeviceModel; }
            set
            {
                selectedDeviceModel = value;
                OnPropertyChanged(nameof(SelectedDeviceModel));
            }
        }
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        private Location selectedLocation;
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }


        /// <summary>
        /// Конструктор ViewModel
        /// </summary>
        /// <param name="deviceGadgetRepository">Хранилище Названий таблиц</param>
        public GeneralDeviceViewModel(IDeviceCommonRepository<GeneralDevice> generalDeviceViewModel, IDeviceCommonRepository<DeviceModel> deviceModelRepository, IDeviceCommonRepository<Location> locationRepository) : base(generalDeviceViewModel)
        {
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<GeneralDevice>(
                    CommonModels.Where(x =>
                        x.IsDelete.Equals(false) && (
                            x.DeviceModel.Name.ToLower().Contains(SearchString) ||
                            x.DeviceModel.DeviceType.Name.ToLower().Contains(SearchString) ||
                            x.Location.Name.ToLower().Contains(SearchString)
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }

    }
}
