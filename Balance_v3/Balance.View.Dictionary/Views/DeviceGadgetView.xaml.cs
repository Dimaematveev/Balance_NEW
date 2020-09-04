using Balance.Model.Dictionaries;
using Balance.View.UserControls.Common;
using Balance.View.Views;
using Balance.ViewModel.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    /// Просмотр редактирование и изменение Названий таблиц
    /// </summary>
    public partial class DeviceGadgetView : Page, IPageView<DeviceType>
    {
        public MyCommonViewModel<DeviceType> myCommonViewModel { get; }

        public DeviceGadgetView()
        {

            InitializeComponent();
            SetEditing();

        }
        public DeviceGadgetView(MyCommonViewModel<DeviceType> myCommonViewModel) : base()
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
