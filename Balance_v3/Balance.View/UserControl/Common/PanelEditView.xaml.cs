using Balance.Model;
using Balance.ViewModel.Dictionary.ViewModel;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Balance.View.UserControls.Common
{
    /// <summary>
    /// Interaction logic for PanelEditView.xaml
    /// </summary>
    public partial class PanelEditView : UserControl
    {
        public PanelEditView()
        {
            InitializeComponent();

        }

        public void SetEditing<T>(object dataContext) where T : CommonModel, new()
        {
            if (dataContext is DeviceCommonViewModel<T> viewModel)
            {
                if (viewModel.IsEditing)
                {
                    string nameResourse = "StartedEditingAnimation";
                    var resourse = TryFindResource(nameResourse) as Storyboard;
                    resourse.Begin();
                }
                else
                {
                    string nameResourse = "StoppedEditingAnimation";
                    var resourse = TryFindResource(nameResourse) as Storyboard;
                    resourse.Begin();
                }
            }

        }
    }
}
