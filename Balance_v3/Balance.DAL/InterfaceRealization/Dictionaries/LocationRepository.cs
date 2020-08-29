using Balance.DAL.Interface.Dictionaries;
using Balance.Model.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization.Dictionaries
{
    /// <summary>
    /// Хранилище Местоположений
    /// </summary>
    public class LocationRepository : MyDeviceCommonRepository<Location>, ILocationRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "Location";



        protected override List<SqlParameter> GetSqlParameters(Location commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@LocationName", commonModel?.Name)
            };
            return sqlParameters;
        }



        protected override Location GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
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
