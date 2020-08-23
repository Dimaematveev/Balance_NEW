using Balance.Model.Dictionary;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.Dictionary.View.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceGadgetViewModel : DeviceCommonViewModel<DeviceGadget>
    {



        public DeviceGadgetViewModel() : base(App.deviceGadgetDataService)
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
