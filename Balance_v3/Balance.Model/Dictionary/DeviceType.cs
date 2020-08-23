namespace Balance.Model.Dictionary
{
    /// <summary>
    /// Тип устройства
    /// </summary>
    public class DeviceType : CommonModel
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

        private DeviceGadget _DeviceGadget;
        public DeviceGadget DeviceGadget
        {
            get { return _DeviceGadget; }
            set
            {
                _DeviceGadget = value;
                OnPropertyChanged(nameof(DeviceGadget));
            }
        }

        /// <summary>
        /// Скопировать текущий объект в новый
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public override CommonModel Clone()
        {
            DeviceType newTypeDevice = new DeviceType();
            newTypeDevice.Fill(this);
            return newTypeDevice;
        }
        /// <summary>
        /// Заполнить текущий объект из переданного
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is DeviceType copyDeviceType)
            {
                DeviceGadget = copyDeviceType.DeviceGadget;

                Name = copyDeviceType.Name;
            }
        }
    }
}
