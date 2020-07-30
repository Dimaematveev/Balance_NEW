using Connected;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace EditAddDevice
{
    /// <summary>
    /// Interaction logic for SelectTypeDevice.xaml
    /// </summary>
    public partial class SelectTypeDevice : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        readonly Connect Con;
        public SelectTypeDevice(Connect con)
        {
            InitializeComponent();
            Con = con;
            Loaded += SelectTypeDevice_Loaded;

            SelectType.Click += SelectType_Click;
        }

        private void SelectType_Click(object sender, RoutedEventArgs e)
        {
            var dataRow = (DataRowView)(TypeDevice.SelectedItem);
            if (dataRow.Row["GadgetName"].Equals("Printer")) 
            {
                //var addPrinter = new AddPrinter(Con, (int)dataRow.Row["ID"]);
                //addPrinter.ShowDialog();
            }
        }

        private void SelectTypeDevice_Loaded(object sender, RoutedEventArgs e)
        {
            TypeDevice.ItemsSource = Con.GetData("Select * from dic.Type").DefaultView;
            TypeDevice.DisplayMemberPath = "Name";

        }
    }
}
