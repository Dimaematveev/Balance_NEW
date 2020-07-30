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
    /// Interaction logic for AddPrinter.xaml
    /// </summary>
    public partial class AddDevice : Window
    {
        readonly Connect Con;
        public AddDevice(Connect con)
        {
            InitializeComponent();
            Con = con;
            Loaded += AddPrinter_Loaded;

            Cancel.Click += Cancel_Click;

            Add.Click += Add_Click;

            AddType.SelectionChanged += AddType_SelectionChanged;
        }

        private void AddType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (AddType.SelectedItem is DataRowView selectType)
            {
                if(selectType.Row["GadgetName"].Equals("Printer"))
                {

                    AddPrinter addPrinter = new AddPrinter();
                    this.Height = this.MinHeight;
                    AddOtherDevice.Children.Clear();
                    AddOtherDevice.Children.Add(addPrinter);
                    this.Height += addPrinter.Height;
                    
                }
                else
                {
                    this.Height = this.MinHeight;
                    AddOtherDevice.Children.Clear();
                }
                
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (AddModel.SelectedItem != null && AddSN != null && AddYear != null/* && AddPagesPerMinute != null*/)
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@ModelID", (int)(((DataRowView)AddModel.SelectedItem)["ID"])));
              
                sqlParameters.Add(new SqlParameter("@SN", AddSN.Text));
                sqlParameters.Add(new SqlParameter("@Year", AddYear.Text));
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
                //sqlParameters.Add(new SqlParameter("@PagesPerMinute", int.Parse(AddPagesPerMinute.Text)));
                string exeption = Con.ExecuteProcedure("[dev].[Add_Printer]", sqlParameters.ToArray());
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

            //AddModel.ItemsSource = Con.GetData($"select * from dic.[Model] where [TypeID] = {TypeID.ToString()}").DefaultView;
            //AddModel.DisplayMemberPath = "Name";
            AddSP.ItemsSource = Con.GetData($"select ID, 'RegNum=' + [RegisterNumber] + '; Deal=' + [Deal] + '; Page=' + [Page] as [Name] from dic.[Sp_Si] where [IsSp] = 1").DefaultView;
            AddSP.DisplayMemberPath = "Name";
            AddSI.ItemsSource = Con.GetData($"select ID, 'RegNum=' + [RegisterNumber] + '; Deal=' + [Deal] + '; Page=' + [Page] as [Name] from dic.[Sp_Si] where [IsSp] = 0").DefaultView;
            AddSI.DisplayMemberPath = "Name";
            AddLocation.ItemsSource = Con.GetData($"select * from [dic].[Location]").DefaultView;
            AddLocation.DisplayMemberPath = "Name";
        }
    }
}
