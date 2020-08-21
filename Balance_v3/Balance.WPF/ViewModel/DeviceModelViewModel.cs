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
        public DeviceModelViewModel() : base(App.deviceModelRepository)
        {
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<DeviceModel>(
                    CommonModels.Where(x => x.Name.ToLower().Contains(SearchString))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
