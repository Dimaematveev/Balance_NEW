using Balance.Model.Dictionaries;
using Balance.View.UserControls.Common;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    /// Просмотр редактирование и изменение Названий таблиц
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
            ViewModelLocator.DeviceGadgetViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<DeviceGadget>(DataContext);
        }
    }
}
