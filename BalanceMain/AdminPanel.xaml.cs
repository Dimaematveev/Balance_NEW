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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            Loaded += AdminPanel_Loaded;
           
        }

        private void AdminPanel_Loaded(object sender, RoutedEventArgs e)
        {
            DictionaryName_Click(null, null);
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
