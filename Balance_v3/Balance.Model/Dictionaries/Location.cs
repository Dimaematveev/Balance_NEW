namespace Balance.Model.Dictionaries
{
    /// <summary>
    /// Местоположение
    /// </summary>
    public class Location : CommonModel
    {
        /// <summary>
        /// Название Местоположения
        /// </summary>
        private string _Name;
        /// <summary>
        /// Название Местоположения
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
            return new Location();
        }

        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is Location copyDeviceType)
            {
                Name = copyDeviceType.Name;
            }
        }
    }
}
