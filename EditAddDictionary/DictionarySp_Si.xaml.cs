using Connected;
using System;
using System.Data;
using System.Windows;

namespace EditAddDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DictionarySp_Si : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        private DataRow DR { get; }

        public DictionarySp_Si(DataRow dr)
        {
            InitializeComponent();
            DR = dr;
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;
            Loaded += DictionaryType_Loaded;
        }

        private void DictionaryType_Loaded(object sender, RoutedEventArgs e)
        {
            RegisterNumberName.Text = DR["RegisterNumber"].ToString();
            DealName.Text = DR["Deal"].ToString();
            PageName.Text = DR["Page"].ToString();
            TypeCheckName.Items.Add("СП");
            TypeCheckName.Items.Add("СИ");
            if (DR["IsSp"].Equals(true)) 
            {
                TypeCheckName.SelectedItem = ("СП");
            }
            else
            {
                TypeCheckName.SelectedItem = ("СИ");
            }
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
            bool isSp = TypeCheckName.SelectedItem.Equals("СП");
            if (DR["ID"] == DBNull.Value)
            {
                exeption=Connect.ExecAction($"INSERT INTO [dic].[Sp_Si] ([RegisterNumber],[Deal],[Page],[IsSp]) VALUES (N'{RegisterNumberName.Text}',N'{DealName.Text}',N'{PageName.Text}',{isSp.ToString().ToLower()})");
            }
            else
            {
                exeption=Connect.ExecAction($"Update [dic].[Sp_Si] set [RegisterNumber] = N'{RegisterNumberName.Text}', [Deal] = N'{DealName.Text}', [Page] = N'{PageName.Text}', [IsSp] = '{isSp.ToString().ToLower()}' where ID = {DR["ID"]}");
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
