using Connected;
using System;
using System.Data;
using System.Windows;

namespace EditAddDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DictionaryModel : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        private DataRow DR { get; }

        public DictionaryModel(DataRow dr)
        {
            InitializeComponent();
            DR = dr;
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;
            Loaded += DictionaryType_Loaded;
        }

        private void DictionaryType_Loaded(object sender, RoutedEventArgs e)
        {
            TypeName.ItemsSource = Connect.GetData("select * from [dic].[Type]").DefaultView;
            TypeName.DisplayMemberPath = "Name";

            //TODO:надо как-то переделать выбор типа по id типа
            var typeID = (int)DR["TypeID"];
            ((DataView)TypeName.ItemsSource).RowFilter = $"ID={typeID}";
            var findItem = ((DataView)TypeName.ItemsSource)[0];
            ((DataView)TypeName.ItemsSource).RowFilter = $"";
            TypeName.SelectedItem = findItem;


            ModelName.Text = DR["Name"].ToString();
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
            var typeId = ((DataRowView)TypeName.SelectedItem).Row["ID"];
            if (DR["ID"] == DBNull.Value)
            {
                exeption=Connect.ExecAction($"INSERT INTO [dic].[Model] ([TypeId],[Name]) VALUES ({typeId},N'{ModelName.Text}')");
            }
            else
            {
                exeption=Connect.ExecAction($"Update [dic].[Model] set [TypeId] = {typeId}, [Name] = N'{ModelName.Text}' where ID = {DR["ID"]}");
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
