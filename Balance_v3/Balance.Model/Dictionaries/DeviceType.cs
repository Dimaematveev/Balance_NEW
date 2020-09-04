namespace Balance.Model.Dictionaries
{
    /// <summary>
    /// Тип устройства
    /// </summary>
    public class DeviceType : CommonModel
    {
        /// <summary>
        /// Название типа устройства
        /// </summary>
        private string _Name;
        /// <summary>
        /// Название типа устройства
        /// </summary>
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
        /// Таблица устройства
        /// </summary>
        private DeviceType _DeviceGadget;
        /// <summary>
        /// Таблица устройства
        /// </summary>
        public DeviceType DeviceGadget
        {
            get { return _DeviceGadget; }
            set
            {
                _DeviceGadget = value;
                OnPropertyChanged(nameof(DeviceGadget));
            }
        }

        public override CommonModel CreateNewCommonModel()
        {
            return new DeviceType();
        }

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
