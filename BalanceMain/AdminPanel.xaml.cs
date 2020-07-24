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
        public AdminPanel()
        {
            InitializeComponent();

            ViewDevice.Click += ViewDevice_Click;
            DictionaryName.Click += DictionaryName_Click;
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
