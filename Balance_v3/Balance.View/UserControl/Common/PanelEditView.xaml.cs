using Balance.Model;
using Balance.ViewModel.Interface;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Balance.View.UserControls.Common
{
    /// <summary>
    /// Группа кнопок. Удалить, сохранить, Отменить изменения/ Редактировать
    /// </summary>
    public partial class PanelEditView : UserControl
    {
        public PanelEditView()
        {
            InitializeComponent();

        }

        public void SetEditing<T>(object dataContext) where T : CommonModel, new()
        {
            if (dataContext is MyCommonViewModel<T> viewModel)
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
