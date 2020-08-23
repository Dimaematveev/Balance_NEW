using Balance.Model.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace Balance.WPF.View
{
    /// <summary>
    /// Interaction logic for DeviceTypeView.xaml
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
            ViewModelLocator.DeviceModelViewModel.editingAnimation = SetEditing;
        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceModel>(DataContext);
        }
    }
}
