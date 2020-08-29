using Balance.Model.Dictionaries;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    ///  Просмотр редактирование и изменение Типов устройств
    /// </summary>
    public partial class DeviceTypeView : Page
    {
        public DeviceTypeView()
        {

            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.DeviceTypeViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceType>(DataContext);
        }
    }
}
