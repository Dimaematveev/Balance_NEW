﻿using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using Balance.ViewModel.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.ViewModel.Dictionary.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceGadgetViewModel : CommonViewModel<DeviceGadget>
    {
        public DeviceGadgetViewModel(IDeviceCommonRepository<DeviceGadget> deviceGadgetRepository) : base(deviceGadgetRepository)
        {
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<DeviceGadget>(
                    CommonModels.Where(x =>
                        x.IsDelete.Equals(false) && (
                            x.Name.ToLower().Contains(SearchString)
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
