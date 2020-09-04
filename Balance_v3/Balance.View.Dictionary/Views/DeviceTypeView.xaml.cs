using Balance.Model.Dictionaries;
using Balance.View.Views;
using Balance.ViewModel.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    ///  Просмотр редактирование и изменение Типов устройств
    /// </summary>
    public partial class DeviceTypeView : Page, IPageView<DeviceType>
    {
        public MyCommonViewModel<DeviceType> myCommonViewModel { get; }
        public DeviceTypeView()
        {

            InitializeComponent();
            SetEditing();

        }
        public DeviceTypeView(MyCommonViewModel<DeviceType> myCommonViewModel) : base()
        {
            this.myCommonViewModel = myCommonViewModel;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myCommonViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceType>(DataContext);
        }
    }
}
