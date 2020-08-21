using Balance.DAL.Interface;
using Balance.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@TypeName", deviceType.Name)
                };

                var newDeviceType = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[Add_{TABLE_NAME}]", sqlParameters);
                newDeviceType.Read();
                deviceType.AllFill(GetDeviceTypeFromDataReader(newDeviceType));
                deviceTypes.Add(deviceType);
            }
        }
       
        public void Update(DeviceType deviceType)
        {
            DeviceType deviceTypeToUpdate = deviceTypes.Where(x => x.ID == deviceType.ID).FirstOrDefault();
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@ID", deviceType.ID),
                new SqlParameter("@TypeName", deviceType.Name)
            };
            var newDeviceType = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[Update_{TABLE_NAME}]", sqlParameters);
            newDeviceType.Read();
            deviceType.AllFill(GetDeviceTypeFromDataReader(newDeviceType));
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
        /// Имя Схемы 
        /// </summary>
        private const string SHEMA_NAME = "dic";
        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "DeviceType";

        /// <summary>
        /// Загрузить машины из таблицы
        /// </summary>
        private void LoadDeviceType()
        {
            deviceTypes = new List<DeviceType>();
            var res = DBConnection.instance.ExecuteQuery($"SELECT * FROM [{SHEMA_NAME}].[{TABLE_NAME}]");
            while (res.Read())
            {
                deviceTypes.Add(GetDeviceTypeFromDataReader(res));
            }
            res.Close();
        }
        /// <summary>
        /// Получить [Тип устройства] из таблицы
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <returns></returns>
        private DeviceType GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var newDeviceType = new DeviceType()
            {
                ID = (int)dbDataReader["ID"],
                Name = (string)dbDataReader["Name"],
                IsDelete = (bool)dbDataReader["IsDelete"]
            };
            return newDeviceType;
        }
    }
}
