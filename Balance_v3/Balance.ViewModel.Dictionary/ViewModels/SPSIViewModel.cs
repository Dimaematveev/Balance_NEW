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
    public class SPSIViewModel : MyCommonViewModel<SPSI>
    {

        /// <summary>
        /// Конструктор ViewModel
        /// </summary>
        /// <param name="sPSIRepository">Хранилище СП и СИ</param>
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
