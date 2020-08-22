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
    public class SPSIViewModel : DeviceCommonViewModel<SPSI>
    {
      

     
        public SPSIViewModel() : base(App.SPSIRepository)
        {
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<SPSI>(
                    CommonModels.Where(x => 
                        x.IsDelete.Equals(false) && (
                            x.RegisterNumber.ToLower().Contains(SearchString) ||
                            x.Deal.ToLower().Contains(SearchString) ||
                            x.Page.ToLower().Contains(SearchString)
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
