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
    public class DeviceModelRepository : IDeviceModelRepository
    {
        /// <summary>
        /// Список [Типов устройств]
        /// </summary>
        private List<DeviceModel>  deviceModels;

        public void Delete(DeviceModel deviceModel)
        {
            deviceModels.Remove(deviceModel);
        }

        public void New(DeviceModel deviceModel)
        {
            if (deviceModel != null && deviceModels != null)
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();

                sqlParameters.Add(new SqlParameter("@ModelName", deviceModel.Name));

                var newDeviceType = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[Add_{TABLE_NAME}]", sqlParameters);
                newDeviceType.Read();
                deviceModel.AllFill(GetDeviceTypeFromDataReader(newDeviceType));
                deviceModels.Add(deviceModel);
            }
        }

        public void Update(DeviceModel deviceModel)
        {
            DeviceModel deviceModelToUpdate = deviceModels.Where(x => x.ID == deviceModel.ID).FirstOrDefault();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@ModelName", deviceModel.Name));
            var newDeviceType = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[Update_{TABLE_NAME}]", sqlParameters);
            newDeviceType.Read();
            deviceModel.AllFill(GetDeviceTypeFromDataReader(newDeviceType));
            deviceModelToUpdate = deviceModel;
        }

        public List<DeviceModel> GetAll()
        {
            if (deviceModels == null)
                LoadDeviceType();
            return deviceModels.Where(x => x.IsDelete == false).ToList();
        }

        public DeviceModel GetDetail(int deviceModelID)
        {
            if (deviceModels == null)
                LoadDeviceType();
            return deviceModels.Where(x => x.ID == deviceModelID).FirstOrDefault();
        }


        /// <summary>
        /// Имя Схемы 
        /// </summary>
        private const string SHEMA_NAME = "dic";
        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        private const string TABLE_NAME = "DeviceModel";

        /// <summary>
        /// Загрузить машины из таблицы
        /// </summary>
        private void LoadDeviceType()
        {
            deviceModels = new List<DeviceModel>();
            var res = DBConnection.instance.ExecuteQuery($"SELECT * FROM [{SHEMA_NAME}].[{TABLE_NAME}]");
            while (res.Read())
            {
                deviceModels.Add(GetDeviceTypeFromDataReader(res));
            }
            res.Close();
        }
        /// <summary>
        /// Получить [Тип устройства] из таблицы
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <returns></returns>
        private DeviceModel GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var newDeviceType = new DeviceModel()
            {
                ID = (int)dbDataReader["ID"],
                Name = (string)dbDataReader["Name"],
                IsDelete = (bool)dbDataReader["IsDelete"]
            };
            return newDeviceType;
        }
    }
}
