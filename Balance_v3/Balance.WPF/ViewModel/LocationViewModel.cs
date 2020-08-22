using Balance.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.WPF.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class LocationViewModel : DeviceCommonViewModel<Location>
    {
      

     
        public LocationViewModel() : base(App.locationRepository)
        {
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCommonModels = new ObservableCollection<Location>(
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
