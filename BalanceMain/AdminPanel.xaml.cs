using System.Windows;
using Connected;

namespace BalanceMain
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        Connect con = new Connect();
        public AdminPanel()
        {
            InitializeComponent();

            ViewDevice.Click += ViewDevice_Click;
            DictionaryName.Click += DictionaryName_Click;

           
        }


        private void DictionaryName_Click(object sender, RoutedEventArgs e)
        {
            var view = new EditDictionary(con);
            view.ShowDialog();
        }

        private void ViewDevice_Click(object sender, RoutedEventArgs e)
        {
            var view = new MainWindow(con);
            view.ShowDialog();
        }
    }
}
