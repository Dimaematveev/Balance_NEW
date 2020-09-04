using Balance.Model.Dictionaries;
using Balance.View.Views;
using Balance.ViewModel.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    /// Просмотр редактирование и изменение Моделей устройств
    /// </summary>
    public partial class DeviceModelView : Page, IPageView<DeviceModel>
    {
        public MyCommonViewModel<DeviceModel> myCommonViewModel { get; }
        public DeviceModelView()
        {

            InitializeComponent();
            SetEditing();

        }
        public DeviceModelView(MyCommonViewModel<DeviceModel> myCommonViewModel) : base()
        {
            this.myCommonViewModel = myCommonViewModel;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myCommonViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceModel>(DataContext);
        }
    }
}
