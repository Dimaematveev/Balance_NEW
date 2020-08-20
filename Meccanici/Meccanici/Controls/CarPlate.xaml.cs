using System.Windows.Controls;
using System.Windows.Input;

namespace Meccanici.Controls
{
    /// <summary>
    /// Автомобильный номер
    /// </summary>
    public partial class CarPlate : UserControl
    {
        public CarPlate()
        {
            InitializeComponent();
        }

        private void Plate_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsActionKey(e.Key))
            {
                if (plate.Text.Length < 7)
                {
                    if ((plate.Text.Length < 2 || plate.Text.Length >= 5) && IsNumberKey(e.Key))
                        e.Handled = true;
                    else if ((plate.Text.Length >= 2 && plate.Text.Length < 5) && !IsNumberKey(e.Key))
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
        }

        private bool IsActionKey(Key inKey)
        {
            bool res =   inKey == Key.Delete;
            res = res || inKey == Key.Back;
            res = res || inKey == Key.Tab;
            res = res || inKey == Key.Return;
            res = res || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt);
            return res;
        }

        private bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if (inKey < Key.NumPad0 || inKey > Key.NumPad9)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
