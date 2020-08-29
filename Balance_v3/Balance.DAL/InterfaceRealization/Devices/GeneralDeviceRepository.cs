using Balance.DAL.Interface;
using Balance.DAL.Interface.Devices;
using Balance.DAL.InterfaceRealization.Dictionaries;
using Balance.Model.Devices;
using Balance.Model.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization.Devices
{
    public class GeneralDeviceRepository<T> : MyDeviceCommonRepository<T>, IGeneralDeviceRepository<T> where T:GeneralDevice
    {
        private readonly IDeviceCommonRepository<DeviceModel> deviceModelRepository;
        private readonly IDeviceCommonRepository<Location> locationRepository;

        public GeneralDeviceRepository(IDeviceCommonRepository<DeviceModel> deviceModelRepository, IDeviceCommonRepository<Location> locationRepository)
        {
            this.deviceModelRepository = deviceModelRepository;
            this.locationRepository = locationRepository;
        }

        protected override string SHEMA_NAME => "dev";

        protected override string TABLE_NAME => "Device";

        protected override T GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curDeviceModelID = (int)dbDataReader["DeviceModelID"];
            var curLocationID = (int)dbDataReader["LocationID"];
            var curIsDelete = (bool)dbDataReader["IsDelete"];
            var curLastModified = (DateTime)dbDataReader["LastModified"];
            var curDeviceModel = deviceModelRepository.GetDetail(curDeviceModelID);
            var curLocation = locationRepository.GetDetail(curLocationID);
            var newGeneralDevice = new GeneralDevice()
            {
                ID = curID,
                DeviceModel = curDeviceModel,
                Location = curLocation,
                IsDelete = curIsDelete,
                LastModified = curLastModified,
            };
            return newGeneralDevice as T;
        }

        protected override List<SqlParameter> GetSqlParameters(T commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@LocationID", commonModel?.Location?.ID),
                new SqlParameter("@DeviceModelID", commonModel?.DeviceModel?.ID)
            };
            return sqlParameters;
        }
    }
}
