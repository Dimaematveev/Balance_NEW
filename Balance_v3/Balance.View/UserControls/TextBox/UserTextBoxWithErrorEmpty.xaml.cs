using Balance.View.ValidationRules;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Balance.View.UserControls.TextBox
{
    /// <summary>
    /// Interaction logic for UserTextBoxWithErrorEmpty.xaml
    /// </summary>
    public partial class UserTextBoxWithErrorEmpty : UserControl
    {
        public UserTextBoxWithErrorEmpty()
        {
            InitializeComponent();
        }


        public string BindingPath
        {
            get { return (string)GetValue(BindingPathProperty); }
            set { SetValue(BindingPathProperty, value); }
        }


        public static readonly DependencyProperty BindingPathProperty =
        DependencyProperty.Register("BindingPath", typeof(string), typeof(UserTextBoxWithErrorEmpty));
    }
}
