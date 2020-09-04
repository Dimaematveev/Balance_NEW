using Balance.Model.Dictionaries;
using Balance.View.UserControls.Common;
using Balance.View.Views;
using Balance.ViewModel.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Balance.View.Dictionary.Views
{
    /// <summary>
    ///  Просмотр редактирование и изменение СП и СИ
    /// </summary>
    public partial class SPSIView : Page, IPageView<SPSI>
    {
        public MyCommonViewModel<SPSI> myCommonViewModel { get; }
        public SPSIView()
        {

            InitializeComponent();
            SetEditing();

        }
        public SPSIView(MyCommonViewModel<SPSI> myCommonViewModel) : base()
        {
            this.myCommonViewModel = myCommonViewModel;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myCommonViewModel.EditingAnimation = SetEditing;

        }
        public void SetEditing()
        {
            PanelEditView.SetEditing<SPSI>(DataContext);
        }
    }
}
