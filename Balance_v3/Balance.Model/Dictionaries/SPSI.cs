﻿namespace Balance.Model.Dictionaries
{
    /// <summary>
    /// СП и СИ
    /// </summary>
    public class SPSI : CommonModel
    {
        /// <summary>
        /// Регистрационный номер
        /// </summary>
        private string _RegisterNumber;
        /// <summary>
        /// Регистрационный номер
        /// </summary>
        public string RegisterNumber
        {
            get { return _RegisterNumber; }
            set
            {
                _RegisterNumber = value;
                OnPropertyChanged(nameof(RegisterNumber));
            }
        }
        /// <summary>
        /// Дело
        /// </summary>
        private string _Deal;
        /// <summary>
        /// Дело
        /// </summary>
        public string Deal
        {
            get { return _Deal; }
            set
            {
                _Deal = value;
                OnPropertyChanged(nameof(Deal));
            }
        }
        /// <summary>
        /// Является СП
        /// </summary>
        private bool? _IsSp;
        /// <summary>
        /// Является СП
        /// </summary>
        public bool? IsSp
        {
            get { return _IsSp; }
            set
            {
                _IsSp = value;
                OnPropertyChanged(nameof(IsSp));
            }
        }
        /// <summary>
        /// Страницы
        /// </summary>
        private string _Page;
        /// <summary>
        /// Страницы
        /// </summary>
        public string Page
        {
            get { return _Page; }
            set
            {
                _Page = value;
                OnPropertyChanged(nameof(Page));
            }
        }
        public override CommonModel CreateNewCommonModel()
        {
            return new SPSI();
        }

        public override void Fill(CommonModel copy)
        {
            if (copy != null && copy is SPSI copyDeviceType)
            {
                RegisterNumber = copyDeviceType.RegisterNumber;
                Deal = copyDeviceType.Deal;
                Page = copyDeviceType.Page;
                IsSp = copyDeviceType.IsSp;
            }
        }
    }


    public class CheckType
    {
        public string Name { get; set; }
        public bool? IsSp { get; set; }

        public string this[bool? isSp] { get => Name; set => Name = value; }
        public bool? this[string Name] { get => IsSp; set => IsSp = value; }



    }
}
