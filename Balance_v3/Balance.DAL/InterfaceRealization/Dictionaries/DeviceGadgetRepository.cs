using Balance.DAL.Interface.Dictionaries;
using Balance.Model.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization.Dictionaries
{
    /// <summary>
    /// Хранилище Имен таблиц
    /// </summary>
    public class DeviceGadgetRepository : MyDeviceCommonRepository<DeviceGadget>, IDeviceGadgetRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "DeviceGadget";



        protected override List<SqlParameter> GetSqlParameters(DeviceGadget commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@GadgetName", commonModel?.Name)
            };
            return sqlParameters;
        }



        protected override DeviceGadget GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curName = (string)dbDataReader["Name"];
            var curIsDelete = (bool)dbDataReader["IsDelete"];
            var curLastModified = (DateTime)dbDataReader["LastModified"];
            var newDeviceGadget = new DeviceGadget()
            {
                ID = curID,
                Name = curName,
                IsDelete = curIsDelete,
                LastModified = curLastModified,
            };
            return newDeviceGadget;
        }
    }
}
