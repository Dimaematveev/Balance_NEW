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
using System.Windows.Shapes;

namespace BalanceMain
{
    /// <summary>
    /// Interaction logic for EditDictionary.xaml
    /// </summary>
    public partial class EditDictionary : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        Connect con;
        public EditDictionary(Connect con)
        {
            this.con = con;
            InitializeComponent();

            Add.Click += Add_Click;

            Type.Selected += Type_Selected;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Type.IsSelected)
            {
                EditAddDictionary.DictionaryType dictionaryType = new EditAddDictionary.DictionaryType();
                dictionaryType.ShowDialog();
            }
        }

        private void Type_Selected(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            var reader = con.ExecuteCommand("Select * from dic.Type");
            reader.Fill(ds);
            ViewDictionary.DataSource = ds.Tables[0];
        }
    }
}
