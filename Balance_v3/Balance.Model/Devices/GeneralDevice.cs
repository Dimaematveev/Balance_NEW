using Balance.Model.Dictionaries;

namespace Balance.Model.Devices
{
    /// <summary>
    /// Общее устройство
    /// </summary>
    public class GeneralDevice : CommonModel
    {
        /// <summary>
        /// Модель устройства
        /// </summary>
        private DeviceModel _DeviceModel;
        /// <summary>
        /// Модель устройства
        /// </summary>
        public DeviceModel DeviceModel
        {
            get { return _DeviceModel; }
            set
            {
                _DeviceModel = value;
                OnPropertyChanged(nameof(DeviceModel));
            }
        }
        /// <summary>
        /// Местоположение устройства
        /// </summary>
        private Location _Location;
        /// <summary>
        /// Местоположение устройства
        /// </summary>
        public Location Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
       
        public override void Fill(CommonModel copy)
        {

            if (copy != null && copy is GeneralDevice copyGeneralDevice)
            {
                DeviceModel = copyGeneralDevice.DeviceModel;
                Location = copyGeneralDevice.Location;
            }
        }

        public override CommonModel CreateNewCommonModel()
        {
            return new GeneralDevice();
        }
    }
}
