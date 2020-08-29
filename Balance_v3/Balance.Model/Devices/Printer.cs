namespace Balance.Model.Devices
{
    /// <summary>
    /// Устройство принтер
    /// </summary>
    public class Printer : GeneralDevice
    {
        /// <summary>
        /// Кол-во страниц в минуту
        /// </summary>
        private int _PagesPerMinute;
        /// <summary>
        /// Кол-во страниц в минуту
        /// </summary>
        public int PagesPerMinute
        {
            get { return _PagesPerMinute; }
            set
            {
                _PagesPerMinute = value;
                OnPropertyChanged(nameof(PagesPerMinute));
            }
        }
        public override CommonModel CreateNewCommonModel()
        {
            return new Printer();
        }

        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is Printer copyPrinter)
            {
                base.Fill(copyPrinter);
                PagesPerMinute = copyPrinter.PagesPerMinute;
            }
        }
    }
}
