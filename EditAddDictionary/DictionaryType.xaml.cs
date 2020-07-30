using Connected;
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
        private DataRow DR { get; }
        private readonly Connect Connect;

        public DictionaryType(Connect connect , DataRow dr)
        {
            InitializeComponent();
            DR = dr;
            Connect = connect;
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;
            Loaded += DictionaryType_Loaded;
        }

        private void DictionaryType_Loaded(object sender, RoutedEventArgs e)
        {
            GadgetName.Items.Add("Monitor");
            GadgetName.Items.Add("Printer");
            GadgetName.SelectedItem = DR["GadgetName"].ToString();
            Name.Text = DR["Name"].ToString();
            if (DR["ID"] != DBNull.Value)
            {
                Add.Content = "Изменить";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string exeption = "";
            if (DR["ID"] == DBNull.Value)
            {
                exeption=Connect.ExecAction($"INSERT INTO [dic].[Type] ([GadgetName],[Name]) VALUES (N'{GadgetName.SelectedItem}',N'{Name.Text}')");
            }
            else
            {
                exeption=Connect.ExecAction($"Update [dic].[Type] set [GadgetName] = N'{GadgetName.SelectedItem}', [Name] = N'{Name.Text}' where ID = {DR["ID"]}");
            }
            if (exeption!=null)
            {
                MessageBox.Show(exeption, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }


    }
}
