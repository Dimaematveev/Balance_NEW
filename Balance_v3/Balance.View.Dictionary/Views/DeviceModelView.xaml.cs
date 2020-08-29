using Balance.Model.Dictionaries;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    /// Просмотр редактирование и изменение Моделей устройств
    /// </summary>
    public partial class DeviceModelView : Page
    {
        public DeviceModelView()
        {

            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.DeviceModelViewModel.EditingAnimation = SetEditing;
        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceModel>(DataContext);
        }
    }
}
