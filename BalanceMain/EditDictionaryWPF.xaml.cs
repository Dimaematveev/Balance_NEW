using Connected;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace BalanceMain
{
    /// <summary>
    /// Interaction logic for EditDictionary.xaml
    /// </summary>
    public partial class EditDictionaryWPF : Window
    {
        /// <summary> таблица с данными </summary>
        DataTable Table;
        /// <summary> Выбранное дерево </summary>
        TreeViewItem SelectTreeViewItem;
        public EditDictionaryWPF()
        {
            InitializeComponent();

            Add.Click += Add_Click;
            Edit.Click += Edit_Click; ;

            Type.Selected += (s, e) => { SelectTreeViewItem = (TreeViewItem) s; FillTable(); };
            Model.Selected += (s, e) => { SelectTreeViewItem = (TreeViewItem) s; FillTable(); };
            Location.Selected += (s, e) => { SelectTreeViewItem = (TreeViewItem) s; FillTable(); };
            Sp_Si.Selected += (s, e) => { SelectTreeViewItem = (TreeViewItem) s; FillTable(); };

        }
        

        private Window GetDictionaryOpen(DataRow dataRow)
        {
            Window DictionaryOpen;
            switch (SelectTreeViewItem.Name)
            {
                case "Type":
                    DictionaryOpen = new EditAddDictionary.DictionaryTypeWPF(dataRow);
                    break;
                case "Model":
                    DictionaryOpen = new EditAddDictionary.DictionaryModelWPF(dataRow);
                    break;
                case "Location":
                    DictionaryOpen = new EditAddDictionary.DictionaryLocationWPF(dataRow);
                    break;
                case "Sp_Si":
                    DictionaryOpen = new EditAddDictionary.DictionarySp_SiWPF(dataRow);
                    break;
                default:
                    DictionaryOpen = null;
                    MessageBox.Show($"Не предусмотрел - {SelectTreeViewItem.Name}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            return DictionaryOpen;
        }
        //TODO: Нет проверок, sql может выдавать ошибки!!
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectTreeViewItem == null || ViewDictionary.DataSource == null || ViewDictionary.Rows.Count == 0)
            {
                return;
            }
            
            var row = Table.Rows[ViewDictionary.SelectedCells[0].RowIndex];
            Window DictionaryOpen = GetDictionaryOpen(row);
            if (DictionaryOpen==null)
            {
                return;
            }
            if (ViewDictionary.SelectedCells.Count >= 1)
            {

                DictionaryOpen.ShowDialog();
                if (!DictionaryOpen.DialogResult.Value)
                {
                    return;
                }
                
                FillTable();

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var row = ((DataTable)ViewDictionary.DataSource).NewRow();
            Window DictionaryOpen = GetDictionaryOpen(row);

            DictionaryOpen.ShowDialog();
            if (!DictionaryOpen.DialogResult.Value)
            {
                return;
            }
            FillTable();
            
        }

        private void FillTable()
        {
            if (SelectTreeViewItem == null)
            {
                return;
            }
            Table = ConnectBL.GetData($"Select * from [dic].[{SelectTreeViewItem.Name}]");
            ViewDictionary.DataSource = Table;
                
        }
    }
}
