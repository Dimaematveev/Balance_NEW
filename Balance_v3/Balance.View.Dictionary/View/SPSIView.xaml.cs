using Balance.Model.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.View
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
            ViewModelLocator.SPSIViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<SPSI>(DataContext);
        }
    }
}
