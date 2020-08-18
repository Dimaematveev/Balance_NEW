using System.Windows;

namespace Balance.WPF
{
    /// <summary>
    /// Interaction logic for AddEditType.xaml
    /// </summary>
    public partial class AddEditType : Window
    {
        public AddEditType()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
}
