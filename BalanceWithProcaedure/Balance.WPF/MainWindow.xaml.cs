using Balance.BL;
using System.Windows;

namespace Balance.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindowFactory
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new TypeDeviceModelView();
        }
        public Window CreateNewWindow()
        {
            AddEditType window = new AddEditType();
            return window;
        }
    }
}
