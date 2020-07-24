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

namespace BalanceMain
{
    /// <summary>
    /// Interaction logic for EditDictionary.xaml
    /// </summary>
    public partial class EditDictionary : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        Connect con;
        /// <summary> заполняет DataSet данными из БД.</summary>
        SqlDataAdapter reader;
        DataSet ds = new DataSet();

        public EditDictionary(Connect con)
        {
            this.con = con;
            InitializeComponent();

            Add.Click += Add_Click;
            Edit.Click += Edit_Click; ;

            Type.Selected += (s, e) => { Type_Selected(); };

            
        }
        //TODO: Нет проверок, sql может выдавать ошибки!!
 

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ViewDictionary.DataSource == null || ViewDictionary.Rows.Count == 0)
            {
                return;
            }
            if (Type.IsSelected && ViewDictionary.SelectedCells.Count >= 1)
            {
                var row = ds.Tables[0].Rows[ViewDictionary.SelectedCells[0].RowIndex];
                EditAddDictionary.DictionaryType dictionaryType = new EditAddDictionary.DictionaryType(row);
                dictionaryType.ShowDialog();
                if (!dictionaryType.DialogResult.Value)
                {
                    return;
                }
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(reader);

                reader.Update(ds);
                Type_Selected();

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Type.IsSelected)
            {
                EditAddDictionary.DictionaryType dictionaryType = new EditAddDictionary.DictionaryType(((DataTable)ViewDictionary.DataSource).NewRow());
                dictionaryType.ShowDialog();
                if (!dictionaryType.DialogResult.Value)
                {
                    return;
                }
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(reader);
                ds.Tables[0].Rows.Add(dictionaryType.DR);
                reader.Update(ds);
                Type_Selected();
            }
        }

        private void Type_Selected()
        {
            
            reader = con.ExecuteCommand("Select * from dic.Type");
            ds.Clear();
            reader.Fill(ds);
            ViewDictionary.DataSource = ds.Tables[0];
        }
    }
}
