using Balance.Model.Dictionaries;
using Balance.View.Views;
using Balance.ViewModel.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    ///  Просмотр редактирование и изменение Местоположений
    /// </summary>
    public partial class LocationView : Page, IPageView<Location>
    {
        public MyCommonViewModel<Location> myCommonViewModel { get; }
        public LocationView()
        {

            InitializeComponent();
            SetEditing();

        }
        public LocationView(MyCommonViewModel<Location> myCommonViewModel) : base()
        {
            this.myCommonViewModel = myCommonViewModel;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myCommonViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<Location>(DataContext);
        }
    }
}
