using Balance.Model.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace Balance.WPF.View
{
    /// <summary>
    /// Interaction logic for DeviceTypeView.xaml
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
            ViewModelLocator.DeviceTypeViewModel.editingAnimation = SetEditing;
            
        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceType>(DataContext);
        }
    }
}
