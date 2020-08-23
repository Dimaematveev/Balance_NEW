using Balance.Model.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace Balance.Dictionary.WPF.View
{
    /// <summary>
    /// Interaction logic for DeviceGadgetView.xaml
    /// </summary>
    public partial class LocationView : Page
    {
        public LocationView()
        {

            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.LocationViewModel.editingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<Location>(DataContext);
        }
    }
}
