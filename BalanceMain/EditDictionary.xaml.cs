using System.Data;
using System.Windows;
using Connected;

namespace BalanceMain
{
    /// <summary>
    /// Interaction logic for EditDictionary.xaml
    /// </summary>
    public partial class EditDictionary : Window
    {
        /// <summary> таблица с данными </summary>
        DataTable Table;

        public EditDictionary()
        {
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
                var row = Table.Rows[ViewDictionary.SelectedCells[0].RowIndex];
                EditAddDictionary.DictionaryType dictionaryType = new EditAddDictionary.DictionaryType(row);
                dictionaryType.ShowDialog();
                if (!dictionaryType.DialogResult.Value)
                {
                    return;
                }
                
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
                Type_Selected();
            }
        }

        private void Type_Selected()
        {

            Table = Connect.GetData("Select * from dic.Type");
            ViewDictionary.DataSource = Table;
        }
    }
}
