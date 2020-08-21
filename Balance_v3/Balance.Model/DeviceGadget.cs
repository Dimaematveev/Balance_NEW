using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.Model
{
    /// <summary>
    /// Название Таблицы
    /// </summary>
    public class DeviceGadget : CommonModel
    {

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Скопировать текущий объект в новый
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public override CommonModel Clone()
        {
            DeviceGadget newTypeDevice = new DeviceGadget();
            newTypeDevice.Fill(this);
            return newTypeDevice;
        }
        /// <summary>
        /// Заполнить текущий объект из переданного
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is DeviceGadget copyDeviceType)
            {
                Name = copyDeviceType.Name;
            }
        }
    }
}
