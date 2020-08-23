using Balance.Model.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace Balance.WPF.View
{
    /// <summary>
    /// Interaction logic for DeviceGadgetView.xaml
    /// </summary>
    public partial class DeviceGadgetView : Page
    {
        public DeviceGadgetView()
        {
            
            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.DeviceGadgetViewModel.editingAnimation = SetEditing;
            
        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceGadget>(DataContext);
        }
    }
}
