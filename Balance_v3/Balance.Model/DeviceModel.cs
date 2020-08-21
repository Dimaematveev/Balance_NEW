using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.Model
{
    /// <summary>
    /// Модель устройства
    /// </summary>
    public class DeviceModel : CommonModel
    {
        public override int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public override bool IsDelete
        {
            get { return _IsDelete; }
            set
            {
                _IsDelete = value;
                OnPropertyChanged(nameof(IsDelete));
            }
        }

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
            DeviceModel newTypeDevice = new DeviceModel();
            newTypeDevice.Fill(this);
            return newTypeDevice;
        }
        /// <summary>
        /// Заполнить текущий объект из переданного
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is DeviceModel copyDeviceModel)
            {
                Name = copyDeviceModel.Name;
            }
        }
    }
}
