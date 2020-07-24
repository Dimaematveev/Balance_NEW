using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditAddDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DictionaryType : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        public DataRow DR { get; }
        public DictionaryType(DataRow dr)
        {
            InitializeComponent();
            DR = dr;
           
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;
            Loaded += DictionaryType_Loaded;
        }

        private void DictionaryType_Loaded(object sender, RoutedEventArgs e)
        {
            
            GadgetName.Text = DR["GadgetName"].ToString();
            Name.Text = DR["Name"].ToString();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DR["GadgetName"] = GadgetName.Text;
            DR["Name"] = Name.Text;
            DialogResult = true;
            Close();
        }


    }
}
