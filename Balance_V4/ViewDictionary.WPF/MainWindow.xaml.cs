using Balance.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ViewDictionary.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BalanceEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db = new BalanceEntities();
            LoadAll();
            Init();
        }

        private void Init()
        {
            DataGrid dataGrid1 = new DataGrid();
            db.TypeOfDevices.Load();
            dataGrid1.ItemsSource = db.TypeOfDevices.Local.ToBindingList(); 
            TypeDevice.Children.Add(dataGrid1);

            DataGrid dataGrid2 = new DataGrid();
            db.ModelOfDevices.Load();
            dataGrid2.ItemsSource = db.ModelOfDevices.Local.ToBindingList();
            ModelDevice.Children.Add(dataGrid2);
        }

        private void LoadAll()
        {
            db.AdditionalFieldForDevices.Load();
            db.AdditionalFields.Load();
            db.DeviceWithAdditionalFields.Load();
            db.Devices.Load();
            db.ModelOfDevices.Load();
            db.TypeOfDevices.Load();
            db.KitLoctions.Load();
            db.Kits.Load();
            db.Locations.Load();
        }
    }
}
