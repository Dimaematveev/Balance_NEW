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
    /// Interaction logic for AddDevice.xaml
    /// </summary>
    public partial class AddDevice : Window, ISingleDevice
    {
        readonly Connect Con;
        private ISingleDevice SpecificDevice;
        public AddDevice(Connect con)
        {
            InitializeComponent();
            Con = con;
            Loaded += AddPrinter_Loaded;

            Cancel.Click += Cancel_Click;

            Add.Click += Add_Click;

            AddType.SelectionChanged += AddType_SelectionChanged;
            AddModel.SelectionChanged += AddModel_SelectionChanged;

        }
        //TODO:надо как-то переделать выбор типа по модели
        private void AddModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AddModel.SelectedItem is DataRowView selectModel)
            {
                var typeID = selectModel.Row["TypeID"];

                 ((DataView)AddType.ItemsSource).RowFilter = $"ID={typeID}";
                var findItem = ((DataView)AddType.ItemsSource)[0];
                ((DataView)AddType.ItemsSource).RowFilter = $"";
                AddType.SelectedItem = findItem;
            }

        }

        /// <summary>
        /// Проверка что все обязательные поля заполнены
        /// </summary>
        public bool Verification()
        {
            bool check = true;
            check = check && AddModel != null;
            check = check && AddSN != null;
            check = check && AddYear != null;
            return check;
        }
        public List<SqlParameter> GetSqlParameters()
        {
            if (Verification())
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                //обязательные параметры мы проверили уже
                sqlParameters.Add(new SqlParameter("@ModelID", (int)(((DataRowView)AddModel.SelectedItem)["ID"])));
                sqlParameters.Add(new SqlParameter("@SN", AddSN.Text));
                sqlParameters.Add(new SqlParameter("@Year", AddYear.Text));

                //необязательные параметры не проверяли
                if (AddSP.SelectedItem is DataRowView sp)
                {
                    sqlParameters.Add(new SqlParameter("@SpID", (int)sp["ID"]));
                }
                if (AddSI.SelectedItem is DataRowView si)
                {
                    sqlParameters.Add(new SqlParameter("@SiID", (int)si["ID"]));
                }
                if (AddLocation.SelectedItem is DataRowView loc)
                {
                    sqlParameters.Add(new SqlParameter("@LocationID", (int)loc["ID"]));
                }
                if (AddIsZip.IsChecked != null)
                {
                    sqlParameters.Add(new SqlParameter("@IsZip", AddIsZip.IsChecked.Value));
                }
                if (AddIsBroken.IsChecked != null)
                {
                    sqlParameters.Add(new SqlParameter("@IsBroken", AddIsBroken.IsChecked.Value));
                }
                return sqlParameters;
            }
            return null;
        }

        private void AddType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (AddType.SelectedItem is DataRowView selectType)
            {

                if(selectType.Row["GadgetName"].Equals("Printer"))
                {
                    var typeID = selectType.Row["ID"];
                    ((DataView)AddModel.ItemsSource).RowFilter = $"TypeID={typeID}";
                    SpecificDevice = new AddPrinter();
                    this.Height = this.MinHeight;
                    AddOtherDevice.Children.Clear();
                    AddOtherDevice.Children.Add(SpecificDevice.GetUIElement());
                    this.Height += SpecificDevice.GetHeight();
                }
                else
                {
                    SpecificDevice = null;
                    ((DataView)AddModel.ItemsSource).RowFilter = "";
                    this.Height = this.MinHeight;
                    AddOtherDevice.Children.Clear();
                }
                
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (SpecificDevice != null && Verification() && SpecificDevice.Verification())
            {
                var sqlParameters = GetSqlParameters();
                sqlParameters.AddRange(SpecificDevice.GetSqlParameters());

                string gadgetName = ((DataRowView)AddType.SelectedItem).Row["GadgetName"].ToString();
                string exeption = Con.ExecuteProcedure($"[dev].[Add_{gadgetName}]", sqlParameters.ToArray());
                if (exeption != null)
                {
                    MessageBox.Show(exeption, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Close();
            }
            else
            {
                MessageBox.Show("Не заполнениы обязательные поля!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddPrinter_Loaded(object sender, RoutedEventArgs e)
        {
            AddType.ItemsSource = Con.GetData("Select * from dic.Type").DefaultView;
            AddType.DisplayMemberPath = "Name";

            AddModel.ItemsSource = Con.GetData($"select * from dic.[Model]").DefaultView;
            //AddModel.ItemsSource = Con.GetData($"select * from dic.[Model] where [TypeID] = {TypeID.ToString()}").DefaultView;
            AddModel.DisplayMemberPath = "Name";
            AddSP.ItemsSource = Con.GetData($"select ID, 'RegNum=' + [RegisterNumber] + '; Deal=' + [Deal] + '; Page=' + [Page] as [Name] from dic.[Sp_Si] where [IsSp] = 1").DefaultView;
            AddSP.DisplayMemberPath = "Name";
            AddSI.ItemsSource = Con.GetData($"select ID, 'RegNum=' + [RegisterNumber] + '; Deal=' + [Deal] + '; Page=' + [Page] as [Name] from dic.[Sp_Si] where [IsSp] = 0").DefaultView;
            AddSI.DisplayMemberPath = "Name";
            AddLocation.ItemsSource = Con.GetData($"select * from [dic].[Location]").DefaultView;
            AddLocation.DisplayMemberPath = "Name";
        }

        public UIElement GetUIElement()
        {
            return this;
        }

        public double GetHeight()
        {
            return Height;
        }
    }
}
