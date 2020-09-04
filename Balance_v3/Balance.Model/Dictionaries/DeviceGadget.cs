namespace Balance.Model.Dictionaries
{
    /// <summary>
    /// Название Таблицы
    /// </summary>
    public class DeviceGadget : CommonModel
    {

        private string _Name;
        /// <summary>
        /// Имя таблицы
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
            return new DeviceType();
        }

        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is DeviceType copyDeviceType)
            {
                Name = copyDeviceType.Name;
            }
        }
    }
}
