using Balance.Model.Dictionaries;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    ///  Просмотр редактирование и изменение Местоположений
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
            ViewModelLocator.LocationViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<Location>(DataContext);
        }
    }
}
