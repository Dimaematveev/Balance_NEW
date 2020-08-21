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
    public class DeviceTypeRepository : DeviceCommonRepository<DeviceType>, IDeviceTypeRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "DeviceType";

       

        internal override List<SqlParameter> GetSqlParameters(DeviceType commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TypeName", commonModel.Name)
            };
            return sqlParameters;
        }


       
        internal override DeviceType GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curName = (string)dbDataReader["Name"];
            var curIsDelete = (bool)dbDataReader["IsDelete"];
            var curLastModified = (DateTime)dbDataReader["LastModified"];
            var newDeviceType = new DeviceType()
            {
                ID = curID,
                Name = curName,
                IsDelete = curIsDelete,
                LastModified = curLastModified,
            };
            return newDeviceType;
        }
    }
}
