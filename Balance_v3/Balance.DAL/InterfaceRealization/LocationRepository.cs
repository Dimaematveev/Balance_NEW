using Balance.DAL.Interface;
using Balance.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization
{
    public class LocationRepository : DeviceCommonRepository<Location>, ILocationRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "Location";

       

        internal override List<SqlParameter> GetSqlParameters(Location commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@LocationName", commonModel.Name)
            };
            return sqlParameters;
        }


       
        internal override Location GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curName = (string)dbDataReader["Name"];
            var curIsDelete = (bool)dbDataReader["IsDelete"];
            var curLastModified = (DateTime)dbDataReader["LastModified"];
            var newLocation = new Location()
            {
                ID = curID,
                Name = curName,
                IsDelete = curIsDelete,
                LastModified = curLastModified,
            };
            return newLocation;
        }
    }
}
