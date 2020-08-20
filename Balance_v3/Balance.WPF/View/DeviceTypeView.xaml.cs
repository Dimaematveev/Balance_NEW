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
    public partial class DeviceTypeView : Page
    {
        public DeviceTypeView()
        {
            
            InitializeComponent();
            SetEditing();

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.DeviceTypeViewModel.editingAnimation = SetEditing;
            
        }
        public void SetEditing()
        {
            var viewModel = DataContext as DeviceTypeViewModel;
            if (viewModel.IsEditing)
                (this.Resources["StartedEditingAnimation"] as Storyboard).Begin();
            else
                (this.Resources["StoppedEditingAnimation"] as Storyboard).Begin();
        }
    }
}
