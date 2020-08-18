using Balance.BL;
using System.Windows;

namespace Balance.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new TypeDeviceModelView();
        }
    }
}
