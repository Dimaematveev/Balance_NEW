using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.Dictionary.ViewModel.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceGadgetViewModel : DeviceCommonViewModel<DeviceGadget>
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
