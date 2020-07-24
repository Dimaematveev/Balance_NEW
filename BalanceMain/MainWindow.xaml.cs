using Co_Combox = System.Windows.Controls.ComboBox;

using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System;


namespace BalanceMain
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        Connect con = new Connect();
        /// <summary> заполняет DataSet данными из БД.</summary>
        SqlDataAdapter reader;


        public MainWindow()
        {

            InitializeComponent();
            /// <summary> словарь для элемента Zip.</summary>
            var DictionaryZip = new List<NameAndIdTable>
            {
                new NameAndIdTable( true, "Да"),
                new NameAndIdTable( false, "Нет"),
            };
            ComboBoxIsZip.ItemsSource = DictionaryZip;

            //MessageBox.Show(con._resultConnection);

            ComboBoxType.PreviewMouseLeftButtonDown += (sender, e) => { ComboBox_Fill((Co_Combox)sender, $"SELECT * FROM dic.Type"); };
            ComboBoxType.SelectionChanged += (sender, e) => { ComboBox_SelectionChangedIsEnable((Co_Combox)sender, ComboBoxModel); };
            ComboBoxModel.PreviewMouseLeftButtonDown += (sender, e) => { ComboBox_Fill((Co_Combox)sender, $"SELECT * FROM dic.Model where TypeID={((NameAndIdTable)ComboBoxType.SelectedItem).ID}"); };
            ComboBoxLocation.PreviewMouseLeftButtonDown += (sender, e) => { ComboBox_Fill((Co_Combox)sender, $"SELECT * FROM dic.Location"); };

            Button_ClearAllComboBox.Click += (sender, e) => { Button_ClearAllComboBox_Click(); };
            Button_View.Click += (sender, e) => { Button_View_Click(); };

            commonDataGridView.MouseDoubleClick += (sender, e) => { DataGridView_NewTab_MouseDoubleClick((DataGridView)sender); };
            deviceDataGridView.MouseDoubleClick += (sender, e) => { DataGridView_NewTab_MouseDoubleClick((DataGridView)sender); };
        }


        /// <summary>
        /// Открывает элемент в новой в кладке
        /// </summary>
        /// <param name="dataGridView">DataGridView с которого была вызвана функция</param>
        private void DataGridView_NewTab_MouseDoubleClick(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows != null)
            {
                var _rowGridView = dataGridView.CurrentRow;
                //Тэг для поиска одинаковых вкладок
                string tag = $"Type:{_rowGridView.Cells["TypeID"].Value}, Device:{_rowGridView.Cells["DeviceID"].Value}.";

                foreach (TabItem item in DataTabControl.Items)
                {
                    if (item.Tag != null && item.Tag.Equals(tag)) 
                    {
                        DataTabControl.SelectedValue = item;
                        DataTabControl.Items.Remove(item);
                        break;
                    }
                }
                //Создание новой вкладки
                var tab = new TabItem()
                {
                    Header = $"{_rowGridView.Cells["TypeName"].Value} {_rowGridView.Cells["ModelName"].Value} SN: {_rowGridView.Cells["SN"].Value}"
                    , Tag = tag
                };
                var _dataGridView = new DataGridView() { ReadOnly = true };
                _dataGridView.AllowUserToAddRows = false;
                //Получение таблицы по GadgetID и DeviceID
                ButtonExecuteSQL($"exec [dev].[ViewAllColumsInOneTableFromOneDevice] {_rowGridView.Cells["DeviceID"].Value}", _dataGridView);

                var _windowsFormHost = new WindowsFormsHost();
                _windowsFormHost.Child = _dataGridView;
                var _grid = new Grid();
                _grid.Children.Add(_windowsFormHost);
                tab.Content = _grid;

                CreateContextMenuOnTab(tab);

                DataTabControl.Items.Add(tab);
                DataTabControl.SelectedValue = tab;
            }
        }

        /// <summary>
        /// Создание Контекстного меню для новых вкладок
        /// </summary>
        /// <param name="tabItem"> Вкладка для которой создается Контекстное меню</param>
        private void CreateContextMenuOnTab(TabItem tabItem)
        {
            var contextMenuTab = new System.Windows.Controls.ContextMenu();
            //Закрыть 1 вкладку
            var contextMenuItemTab = new System.Windows.Controls.MenuItem() { Header = "Close" };
            contextMenuItemTab.Click += (sender1, e1) => { DataTabControl.Items.Remove(tabItem); };
            contextMenuTab.Items.Add(contextMenuItemTab);

            //закрыть все вкладки
            contextMenuItemTab = new System.Windows.Controls.MenuItem() { Header = "CloseAll" };
            contextMenuItemTab.Click += (sender1, e1) => { CloseAllTab(2); };
            contextMenuTab.Items.Add(contextMenuItemTab);

            tabItem.ContextMenu = contextMenuTab;
        }

        /// <summary>
        /// Закрывает все вкладки кроме первых k штук
        /// </summary>
        /// <param name="k"> сколько вкладок не закрываются с начала </param>
        private void CloseAllTab(int k)
        {
            while (DataTabControl.Items.Count > k) 
            {
                DataTabControl.Items.RemoveAt(k);
            }
        }

        /// <summary>
        /// Связываем comboBox с comboBoxNext. 
        /// Так что при обновлении comboBox сбрасывает значение с comboBoxNext
        /// и если comboBox пуст то выключает элемент comboBoxNext и наоборот
        /// </summary>
        /// <param name="comboBox"> Для какого comboBox делаем связь. </param>
        /// <param name="comboBoxNext"> С каким связываем. </param>
        private void ComboBox_SelectionChangedIsEnable(Co_Combox comboBox, Co_Combox comboBoxNext)
        {
            if (comboBox.SelectedItem != null) 
            {
                comboBoxNext.IsEnabled = true;
            }
            else
            {
                comboBoxNext.IsEnabled = false;
            }
            comboBoxNext.SelectedValue = null;
           
        }

        /// <summary>
        /// Вывод значений из SQL в ComboBox
        /// </summary>
        /// <param name="comboBox"> В какой comboBox записать значения </param>
        /// <param name="_sql"> sql запрос </param>
        private void ComboBox_Fill(Co_Combox comboBox,  string _sql)
        {
            comboBox.SelectedItem = null;
            List<NameAndIdTable> dictionary = FillDictionary(_sql);
            comboBox.ItemsSource = dictionary;
            comboBox.DisplayMemberPath = "Name";
        }

        //TODO:Не могу придумать returns
        /// <summary>
        /// Заполнение Dictionary из Базы как Key=ID, Value=Name
        /// </summary>
        /// <param name="_sql">Запрос из которого заполняется заполнение Dictionary  Key=ID, Value=Name</param>
        /// <returns>  </returns>
        private List<NameAndIdTable> FillDictionary(string _sql)
        {
            DataSet ds = new DataSet();

            reader = con.ExecuteCommand(_sql);
            reader.Fill(ds);

            List<NameAndIdTable> dictionary = new List<NameAndIdTable>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                dictionary.Add(new NameAndIdTable(item.Field<object>("ID"), item.Field<string>("Name")));
            }
            return dictionary;
        }

        /// <summary>
        /// Сброс значений в ComboBox через кнопку
        /// </summary>
        private void Button_ClearAllComboBox_Click()
        {
            ComboBoxLocation.SelectedItem = null;
            ComboBoxIsZip.SelectedItem = null;
        }

        /// <summary>
        /// Действие по кнопке Показать. 
        /// </summary>
        private void Button_View_Click()
        {

            if (DataTabControl.SelectedItem == CommonTabItem)
            {
                ButtonExecuteSQL("Select * from [dev].[View_Device]", commonDataGridView);
            }

            if (DataTabControl.SelectedItem == DeviceTabItem)
            {
                if (ComboBoxType.SelectedItem != null)
                {
                    ButtonExecuteSQL($"exec dev.ViewAllColumsInOneTable {((NameAndIdTable)ComboBoxType.SelectedItem).ID}", deviceDataGridView);
                }
                else
                {
                    System.Windows.MessageBox.Show("Не выбрано устройство!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Метод, выполняющий SQL инструкцию, и применяющий фильтры на выводимые столбцы
        /// </summary>
        /// <param name="_sql">Запрос sql</param>
        /// <param name="_dataGridView"> В какой DataGridView будет записаны данные с запроса </param>
        private void ButtonExecuteSQL(string _sql, DataGridView _dataGridView)
        {
            DataSet ds = new DataSet();

            reader = con.ExecuteCommand(_sql);
            reader.Fill(ds);
            _dataGridView.DataSource = ds.Tables[0];
            
            if (_dataGridView == commonDataGridView || _dataGridView == deviceDataGridView)
            {
                _dataGridView.Columns["TypeID"].Visible = false;
                _dataGridView.Columns["ModelID"].Visible = false;
                _dataGridView.Columns["LocationID"].Visible = false;
                _dataGridView.Columns["SPID"].Visible = false;
                _dataGridView.Columns["SIID"].Visible = false;

                foreach (System.Windows.Forms.DataGridViewRow item in _dataGridView.Rows)
                {
                    Grid_Filter(item, "TypeID", ComboBoxType, _dataGridView);
                    Grid_Filter(item, "ModelID", ComboBoxModel, _dataGridView);
                    Grid_Filter(item, "LocationID", ComboBoxLocation, _dataGridView);
                    Grid_Filter(item, "IsZip", ComboBoxIsZip, _dataGridView);
                    item.ReadOnly = true;
                }
            }
            
        }


        //TODO:Наверное стоит filter_ComboBox Сделать просто string или object чем целый combobox
        /// <summary>
        /// Фильтр в DatagridView
        /// </summary>
        /// <param name="row"> полученная строка </param>
        /// <param name="filter_column"> По какой фильтровать </param>
        /// <param name="filter_ComboBox"> Выбранный ComboBox для фильтра </param>
        /// <param name="_dataGridView"> В каком dataGridView производить действие </param>
        private void Grid_Filter(DataGridViewRow row, string filter_column, Co_Combox filter_ComboBox, DataGridView _dataGridView)
        {
            if (filter_ComboBox.SelectedItem != null && row.Cells[filter_column].Value != null)
            {
                var filter_ComboBox_Pair = (NameAndIdTable)filter_ComboBox.SelectedItem;
                if (filter_ComboBox_Pair.Name != null && !filter_ComboBox_Pair.ID.Equals(row.Cells[filter_column].Value)) 
                {
                    _dataGridView.CurrentCell = null;
                    row.Visible = false;
                }
            }
        }
    }
}
