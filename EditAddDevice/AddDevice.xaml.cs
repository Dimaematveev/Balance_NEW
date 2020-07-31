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
        public List<string> Verification()
        {
            List<string> res = new List<string>();
            if (AddModel.SelectedItem == null)
            {
                Grid parent = (Grid)AddModel.Parent;
                res.Add($"Поле [{((Label)parent.Children[0]).Content}] должно быть обязательно заполнено!");
            }
            if (string.IsNullOrEmpty(AddSN.Text) || AddSN.Text.Length > 50)
            {
                Grid parent = (Grid)AddSN.Parent;
                res.Add($"Поле [{((Label)parent.Children[0]).Content}] должно быть обязательно заполнено! И длина должна быть от 1 до 50 символов.Сейчас:{AddSN.Text.Length}.");
            }
            if (string.IsNullOrEmpty(AddYear.Text) || !int.TryParse(AddYear.Text, out int year) || year < 1990 || year > 2100) 
            {
                Grid parent = (Grid)AddYear.Parent;
                
                res.Add($"Поле [{((Label)parent.Children[0]).Content}] должно быть обязательно заполнено! И содержать год от 1990 до 2100. Сейчас:{AddYear.Text}.");
            }
            return res;
        }
        public List<SqlParameter> GetSqlParameters()
        {
            if (Verification().Count == 0)
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                //обязательные параметры мы проверили уже
                sqlParameters.Add(new SqlParameter("@ModelID", (int)(((DataRowView)AddModel.SelectedItem)["ID"])));
                sqlParameters.Add(new SqlParameter("@SN", AddSN.Text));
                sqlParameters.Add(new SqlParameter("@Year", AddYear.Text));

                //необязательные параметры не проверяли на NULL
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
            var verification = Verification();
            if (SpecificDevice != null)
            {
                verification.AddRange(SpecificDevice.Verification());
                if (verification.Count == 0)
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
                    return;
                }
            }
            string str = "";
            foreach (var item in verification)
            {
                str += item + "\n";
            }
            MessageBox.Show(str, "Внимание!Неправильно заполнены поля!", MessageBoxButton.OK, MessageBoxImage.Warning);
            
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
