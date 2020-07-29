using Connected;
using System;
using System.Collections.Generic;
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
    public partial class AddPrinter : Window
    {
        readonly Connect Con;
        public AddPrinter(Connect con)
        {
            InitializeComponent();
            Con = con;
            Loaded += AddPrinter_Loaded;
        }

        private void AddPrinter_Loaded(object sender, RoutedEventArgs e)
        {
            AddModel.ItemsSource = Con.GetData("select * from dic.Model").DefaultView;
            AddModel.DisplayMemberPath = "Name";
        }
    }
}
