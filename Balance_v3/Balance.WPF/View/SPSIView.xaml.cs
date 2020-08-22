using Balance.Model;
using System.Windows;
using System.Windows.Controls;

namespace Balance.WPF.View
{
    /// <summary>
    /// Interaction logic for DeviceGadgetView.xaml
    /// </summary>
    public partial class SPSIView : Page
    {
        public SPSIView()
        {
            
            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.SPSIViewModel.editingAnimation = SetEditing;
            
        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<SPSI>(DataContext);
        }
    }
}
