using Connected;
using System;
using System.Data;
using System.Windows;

namespace EditAddDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DictionaryTypeWPF : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        private DataRow DR { get; }

        public DictionaryTypeWPF(DataRow dr)
        {
            InitializeComponent();
            DR = dr;
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;
            Loaded += DictionaryType_Loaded;
        }

        private void DictionaryType_Loaded(object sender, RoutedEventArgs e)
        {
            var data = ConnectBL.GetData("exec [dbo].[GetNameTableDevice]").Rows;
            foreach (DataRow item in data)
            {
                GadgetName.Items.Add(item[0]);
            }
            
            GadgetName.SelectedItem = DR["GadgetName"].ToString();
            TypeName.Text = DR["Name"].ToString();
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
            string exeption;
            if (DR["ID"] == DBNull.Value)
            {
                exeption=ConnectBL.ExecAction($"INSERT INTO [dic].[Type] ([GadgetName],[Name]) VALUES (N'{GadgetName.SelectedItem}',N'{TypeName.Text}')");
            }
            else
            {
                exeption=ConnectBL.ExecAction($"Update [dic].[Type] set [GadgetName] = N'{GadgetName.SelectedItem}', [Name] = N'{TypeName.Text}' where ID = {DR["ID"]}");
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
