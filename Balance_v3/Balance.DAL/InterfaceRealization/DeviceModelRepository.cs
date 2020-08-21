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
    public class DeviceModelRepository : DeviceCommonRepository<DeviceModel>, IDeviceModelRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "DeviceModel";



        internal override List<SqlParameter> GetSqlParameters(DeviceModel commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@ModelName", commonModel.Name)
            };
            return sqlParameters;
        }



        internal override DeviceModel GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var newDeviceModel = new DeviceModel()
            {
                ID = (int)dbDataReader["ID"],
                Name = (string)dbDataReader["Name"],
                IsDelete = (bool)dbDataReader["IsDelete"]
            };
            return newDeviceModel;
        }
    }
}
