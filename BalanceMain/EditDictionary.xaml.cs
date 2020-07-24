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
    /// Interaction logic for EditDictionary.xaml
    /// </summary>
    public partial class EditDictionary : Window
    {
        public EditDictionary()
        {
            InitializeComponent();

            Type.Selected += Type_Selected;
        }

        private void Type_Selected(object sender, RoutedEventArgs e)
        {
            EditAddDictionary.DictionaryType mainWindow = new EditAddDictionary.DictionaryType();
            mainWindow.ShowDialog();
        }
    }
}
