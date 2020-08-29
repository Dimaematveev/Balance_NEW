using System.Windows;
using System.Windows.Controls;

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
