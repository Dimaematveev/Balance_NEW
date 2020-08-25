using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using Balance.ViewModel.Interface;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.ViewModel.Dictionary.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class LocationViewModel : MyCommonViewModel<Location>
    {


        /// <summary>
        /// Конструктор ViewModel
        /// </summary>
        /// <param name="locationRepository">Хранилище Местоположений</param>
        public LocationViewModel(IDeviceCommonRepository<Location> locationRepository) : base(locationRepository)
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
