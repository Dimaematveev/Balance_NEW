using Balance.Model;
using Balance.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Balance.WPF.View.UserControls.Common
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

        public void SetEditing<T>(object dataContext) where T: CommonModel,new()
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
