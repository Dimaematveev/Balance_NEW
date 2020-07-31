using System.Windows;
using Connected;

namespace BalanceMain
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();

            ViewDevice.Click += ViewDevice_Click;
            DictionaryName.Click += DictionaryName_Click;

            Loaded += AdminPanel_Loaded;
        }

        private void AdminPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (Connect._IsOpen)
            {
                MessageBox.Show(Connect._resultConnection, "Подключение к базе", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(Connect._resultConnection, "Подключение к базе", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            
        }

        private void DictionaryName_Click(object sender, RoutedEventArgs e)
        {
            var view = new EditDictionary();
            view.ShowDialog();
        }

        private void ViewDevice_Click(object sender, RoutedEventArgs e)
        {
            var view = new MainWindow();
            view.ShowDialog();
        }
    }
}
