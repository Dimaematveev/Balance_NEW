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

        public void DeleteCar(DeviceType deviceType)
        {
            deviceTypes.Remove(deviceType);
        }
        public void NewCar(DeviceType deviceType)
        {
            if (deviceType != null && deviceTypes != null)
            {
                //string values = "'" + car.Marca + "','" + car.Modello + "'," + car.Anno + ",'" + car.Targa + "'," + car.ID_Cliente;
                //DBConnection.instance.InsertInto(TABLE_NAME, "Marca,Modello,Anno,PlateCode,Owner_ID", values);
                deviceTypes.Add(deviceType);
            }
        }

        public void UpdateCar(DeviceType deviceType)
        {
            DeviceType deviceTypeToUpdate = deviceTypes.Where(x => x.ID == deviceType.ID).FirstOrDefault();
            deviceTypeToUpdate = deviceType;
        }

        public List<DeviceType> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public DeviceType GetCarDetail(string deviceTypeID)
        {
            throw new NotImplementedException();
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
                    ID = (string)res["ID"],
                    Name = (string)res["Name"],
                    IsDelete = (bool)res["IsDelete"]
                });
            }
            res.Close();
        }
    }
}
