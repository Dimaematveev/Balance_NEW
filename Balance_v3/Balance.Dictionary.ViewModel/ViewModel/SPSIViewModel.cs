using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.Dictionary.ViewModel.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class SPSIViewModel : DeviceCommonViewModel<SPSI>
    {


        public SPSIViewModel(IDeviceCommonRepository<SPSI> sPSIRepository) : base(sPSIRepository)
        {
            SearchString = "";
        }

        public override string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = GetStringForComparison(value);

                FilteredCommonModels = new ObservableCollection<SPSI>(
                    CommonModels.Where(x =>
                        x.IsDelete.Equals(false) && (
                            GetStringForComparison(x.RegisterNumber).Contains(SearchString) ||
                            GetStringForComparison(x.Deal).Contains(SearchString) ||
                            GetStringForComparison(x.Page).Contains(SearchString)
                        ))
                );
                OnPropertyChanged(nameof(SearchString));
            }
        }

    }


}
