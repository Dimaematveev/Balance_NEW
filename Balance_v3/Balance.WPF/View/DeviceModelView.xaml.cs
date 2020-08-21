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

namespace Balance.WPF.View
{
    /// <summary>
    /// Interaction logic for DeviceTypeView.xaml
    /// </summary>
    public partial class DeviceModelView : Page
    {
        public DeviceModelView()
        {
            
            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.DeviceModelViewModel.editingAnimation = SetEditing;
        }
        public void SetEditing()
        {
            var viewModel = DataContext as DeviceModelViewModel;
            if (viewModel.IsEditing)
            {
                string nameResourse = "StartedEditingAnimation";
                var resourse = this.Resources[nameResourse];
                (resourse as Storyboard).Begin();
            }
            else
            {
                string nameResourse = "StoppedEditingAnimation";
                var resourse = this.Resources[nameResourse];
                (resourse as Storyboard).Begin();
            }
        }
    }
}
