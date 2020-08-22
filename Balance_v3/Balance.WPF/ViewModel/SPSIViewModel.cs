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

        public List<CheckType> CheckTypes { get => CheckType.checkTypes; }
     
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
