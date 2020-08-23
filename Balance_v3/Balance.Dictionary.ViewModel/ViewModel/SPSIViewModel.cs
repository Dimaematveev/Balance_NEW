using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Balance.Dictionary.ViewModel.ViewModel
{
    /// <summary>
    /// View-Model  [Типа устройства]
    /// </summary>
    public class SPSIViewModel : DeviceCommonViewModel<SPSI>
    {

        public List<CheckType> CheckTypes { get => CheckType.checkTypes; }

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

    public class CheckType
    {
        public static readonly List<CheckType> checkTypes = new List<CheckType>()
        {
            new CheckType("СП", true ),
            new CheckType("СИ", false ),
            new CheckType("Неизвестно", null ),
        };
        public string Name { get; set; }
        public bool? IsSp { get; set; }
        public static List<CheckType> CheckTypes
        {
            get { return checkTypes; }
        }

        private CheckType(string name, bool? isSP)
        {
            Name = name;
            IsSp = isSP;
        }

        public static CheckType GetCheckType(bool? IsSp)
        {
            return checkTypes.First(x => x.IsSp == IsSp);
        }


    }
}
