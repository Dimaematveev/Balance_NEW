using Balance.DAL.Interface;
using Balance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.DAL.InterfaceRealization
{
    public class DeviceTypeRepository : IDeviceTypeRepository
    {
        /// <summary>
        /// Список [Типов устройств]
        /// </summary>
        private List<DeviceType> deviceTypes;

        public void Delete(DeviceType deviceType)
        {
            deviceTypes.Remove(deviceType);
        }
        public void New(DeviceType deviceType)
        {
            if (deviceType != null && deviceTypes != null)
            {
                //string values = "'" + car.Marca + "','" + car.Modello + "'," + car.Anno + ",'" + car.Targa + "'," + car.ID_Cliente;
                //DBConnection.instance.InsertInto(TABLE_NAME, "Marca,Modello,Anno,PlateCode,Owner_ID", values);
                deviceTypes.Add(deviceType);
            }
        }

        public void Update(DeviceType deviceType)
        {
            DeviceType deviceTypeToUpdate = deviceTypes.Where(x => x.ID == deviceType.ID).FirstOrDefault();
            deviceTypeToUpdate = deviceType;
        }

        public List<DeviceType> GetAll()
        {
            if (deviceTypes == null)
                LoadDeviceType();
            return deviceTypes.Where(x => x.IsDelete == false).ToList();
        }

        public DeviceType GetDetail(int deviceTypeID)
        {
            if(deviceTypes == null)
                LoadDeviceType();
            return deviceTypes.Where(x => x.ID == deviceTypeID).FirstOrDefault();
        }

        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "dic.Device_Type";

        /// <summary>
        /// Загрузить машины из таблицы
        /// </summary>
        private void LoadDeviceType()
        {
            deviceTypes = new List<DeviceType>();
            var res = DBConnection.instance.ExecuteQuery("SELECT * FROM " + TABLE_NAME);
            while (res.Read())
            {
                deviceTypes.Add(new DeviceType()
                {
                    ID = (int)res["ID"],
                    Name = (string)res["Name"],
                    IsDelete = (bool)res["IsDelete"]
                });
            }
            res.Close();
        }

    }
}
