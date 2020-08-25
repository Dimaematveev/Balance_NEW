using Balance.Model.Dictionary;
using Balance.View.UserControls.Common;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.View
{
    /// <summary>
    ///  Просмотр редактирование и изменение СП и СИ
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
