using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using Balance.ViewModel.Interface;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.ViewModel.Dictionary.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceTypeViewModel : MyCommonViewModel<DeviceType>
    {
        /// <summary>
        /// Хранилище Названий таблиц
        /// </summary>
        private readonly IDeviceCommonRepository<DeviceGadget> deviceGadgetRepository;
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
        /// <summary>
        /// Конструктор ViewModel
        /// </summary>
        /// <param name="deviceTypeRepository">Хранилище Типов устройств</param>
        /// <param name="deviceGadgetRepository">Хранилище Названий таблиц</param>
        public DeviceTypeViewModel(IDeviceCommonRepository<DeviceType> deviceTypeRepository, IDeviceCommonRepository<DeviceGadget> deviceGadgetRepository) : base(deviceTypeRepository)
        {
            this.deviceGadgetRepository = deviceGadgetRepository;
            DeviceGadgets = this.deviceGadgetRepository.GetAll().Where(x => x.IsDelete.Equals(false)).ToList();
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
