using Balance.DAL.Interface;
using Balance.Model.Dictionaries;
using Balance.ViewModel.Interface;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.ViewModel.Dictionary.ViewModels
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class DeviceGadgetViewModel : MyCommonViewModel<DeviceType>
    {
        /// <summary>
        /// Конструктор ViewModel
        /// </summary>
        /// <param name="deviceGadgetRepository">Хранилище Названий таблиц</param>
        public DeviceGadgetViewModel(IDeviceCommonRepository<DeviceType> deviceGadgetRepository) : base(deviceGadgetRepository)
        {
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
                            x.Name.ToLower().Contains(SearchString)
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }
    }
}
