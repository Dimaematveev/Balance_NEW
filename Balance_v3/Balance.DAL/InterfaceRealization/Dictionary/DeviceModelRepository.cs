﻿using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization
{
    /// <summary>
    /// Хранилище Моделей устройств
    /// </summary>
    public class DeviceModelRepository : MyDeviceCommonRepository<DeviceModel>, IDeviceModelRepository
    {
        private readonly IDeviceCommonRepository<DeviceType> deviceTypeRepository;

        public DeviceModelRepository(IDeviceCommonRepository<DeviceType> deviceTypeRepository)
        {
            this.deviceTypeRepository = deviceTypeRepository;
        }

        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "DeviceModel";




        internal override List<SqlParameter> GetSqlParameters(DeviceModel commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@ModelName", commonModel?.Name),
                new SqlParameter("@TypeID", commonModel?.DeviceType?.ID)
            };
            return sqlParameters;
        }



        internal override DeviceModel GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curName = (string)dbDataReader["Name"];
            var curDeviceTypeID = (int)dbDataReader["DeviceTypeID"];
            var curIsDelete = (bool)dbDataReader["IsDelete"];
            var curLastModified = (DateTime)dbDataReader["LastModified"];
            var curDeviceType = deviceTypeRepository.GetDetail(curDeviceTypeID);
            var newDeviceModel = new DeviceModel()
            {
                ID = curID,
                Name = curName,
                DeviceType = curDeviceType,
                IsDelete = curIsDelete,
                LastModified = curLastModified,
            };
            return newDeviceModel;
        }
    }
}