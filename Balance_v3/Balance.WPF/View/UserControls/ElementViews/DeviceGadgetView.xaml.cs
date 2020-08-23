using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Balance.WPF.View.UserControls.ElementViews
{
    /// <summary>
    /// Interaction logic for DeviceGadgetView.xaml
    /// </summary>
    public partial class DeviceGadgetView : UserControl
    {
        public DeviceGadgetView()
        {
            InitializeComponent();
            
           
        }
        public IEnumerable ItemsSource
        {
            get
            { 
               return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

       
        public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(DeviceGadgetView));
      

    }
}
