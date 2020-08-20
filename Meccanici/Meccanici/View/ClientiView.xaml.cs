using Meccanici.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Meccanici.View
{
    /// <summary>
    /// Logica di interazione per ClientiView.xaml
    /// </summary>
    public partial class ClientiView : Page
    {
        public ClientiView()
        {
            DataContext = ViewModelLocator.ClientiViewModel;
            InitializeComponent();
        }

        public ClientiView(bool employee)
        {
            DataContext = ViewModelLocator.MeccaniciViewModel;
            InitializeComponent();
        }


        ClientiViewModel viewModel;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = DataContext as ClientiViewModel;
            viewModel.editingAnimation = SetEditing;
        }

        public void SetEditing()
        {
            if (viewModel.IsEditing)
                (this.Resources["StartedEditingAnimation"] as Storyboard).Begin();
            else
                (this.Resources["StoppedEditingAnimation"] as Storyboard).Begin();
        }

    }
}
