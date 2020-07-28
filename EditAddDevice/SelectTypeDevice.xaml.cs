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
        Connect Con;
        public SelectTypeDevice(Connect con)
        {
            InitializeComponent();
            Con = con;
            Loaded += SelectTypeDevice_Loaded;
            
        }

        private void SelectTypeDevice_Loaded(object sender, RoutedEventArgs e)
        {
            
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter = Con.ExecuteCommand("Select * from dic.Type");
            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds);

            TypeDevice.ItemsSource = ds.Tables[0].DefaultView;
            TypeDevice.DisplayMemberPath = "Name";

        }
    }
}
