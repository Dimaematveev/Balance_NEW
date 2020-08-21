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
    public class DeviceGadgetRepository : DeviceCommonRepository<DeviceGadget>, IDeviceGadgetRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "DeviceGadget";

       

        internal override List<SqlParameter> GetSqlParameters(DeviceGadget commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TypeName", commonModel.Name)
            };
            return sqlParameters;
        }


       
        internal override DeviceGadget GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
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
