namespace Balance.Model.Dictionaries
{
    /// <summary>
    /// Модель устройства
    /// </summary>
    public class DeviceModel : CommonModel
    {

        /// <summary>
        /// Тип устройства
        /// </summary>
        private DeviceType _DeviceType;
        /// <summary>
        /// Тип устройства
        /// </summary>
        public DeviceType DeviceType
        {
            get { return _DeviceType; }
            set
            {
                _DeviceType = value;
                OnPropertyChanged(nameof(DeviceType));
            }
        }
        /// <summary>
        /// Название модели устройства
        /// </summary>
        private string _Name;
        /// <summary>
        /// Название модели устройства
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

        public override CommonModel CreateNewCommonModel()
        {
            return new DeviceModel();
        }

        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is DeviceModel copyDeviceModel)
            {

                DeviceType = copyDeviceModel.DeviceType;
                Name = copyDeviceModel.Name;
            }
        }
    }
}
