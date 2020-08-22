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
    public class DeviceGadgetViewModel : DeviceCommonViewModel<DeviceGadget>
    {
      

     
        public DeviceGadgetViewModel() : base(App.deviceGadgetDataService)
        {
           
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<DeviceGadget>(
                    CommonModels.Where(x => 
                        x.IsDelete = false ||
                        x.Name.ToLower().Contains(SearchString) 
                        )
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
