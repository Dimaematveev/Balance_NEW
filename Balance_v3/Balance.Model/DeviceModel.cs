﻿using System;
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
       
        private int _DeviceTypeID;
        public int DeviceTypeID
        {
            get { return _DeviceTypeID; }
            set
            {
                _DeviceTypeID = value;
                OnPropertyChanged(nameof(DeviceTypeID));
            }
        }
        private DeviceType _DeviceType;
        public DeviceType DeviceType
        {
            get { return _DeviceType; }
            set
            {
                _DeviceType = value;
                OnPropertyChanged(nameof(DeviceType));
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
                
                DeviceType = copyDeviceModel.DeviceType;
                DeviceTypeID = copyDeviceModel.DeviceTypeID;
                Name = copyDeviceModel.Name;
            }
        }
    }
}