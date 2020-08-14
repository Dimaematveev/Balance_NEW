using System.Windows;

namespace BalanceMain
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanelWPF : Window
    {
        AdminPanelBL AdminPanel;
        public AdminPanelWPF()
        {
            InitializeComponent();
            AdminPanel = new AdminPanelBL();

            ViewDevice.Click += ViewDevice_Click;
            DictionaryName.Click += DictionaryName_Click;

            Loaded += AdminPanel_Loaded;
            Closing += AdminPanel_Closing;
        }

        private void AdminPanel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AdminPanel.CloseConnected();
        }


        private void AdminPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (AdminPanel.OpenConnected())
            {
                MessageBox.Show(AdminPanel.ResultConnect, "Подключение к базе", MessageBoxButton.OK, MessageBoxImage.Information) ;
            }
            else
            {
                MessageBox.Show(AdminPanel.ResultConnect, "Подключение к базе", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            
        }


        private void DictionaryName_Click(object sender, RoutedEventArgs e)
        {
            var view = new EditDictionaryWPF();
            view.ShowDialog();
        }


        private void ViewDevice_Click(object sender, RoutedEventArgs e)
        {
            var view = new ViewDeviceWPF();
            view.ShowDialog();
        }
    }
}
