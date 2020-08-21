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
    public class SPSIRepository : DeviceCommonRepository<SPSI>, ISPSIRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "SPSI";

       

        internal override List<SqlParameter> GetSqlParameters(SPSI commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@RegisterNumber", commonModel.RegisterNumber),
                new SqlParameter("@Deal", commonModel.Deal),
                new SqlParameter("@Page", commonModel.Page),
                new SqlParameter("@IsSp", commonModel.IsSp),
            };
            return sqlParameters;
        }


       
        internal override SPSI GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curRegisterNumber = (string)dbDataReader["RegisterNumber"];
            var curDeal = (string)dbDataReader["Deal"];
            var curPage = (string)dbDataReader["Page"];
            var curIsSp = (bool)dbDataReader["IsSp"];
            var curIsDelete = (bool)dbDataReader["IsDelete"];
            var curLastModified = (DateTime)dbDataReader["LastModified"];
            var newSPSI = new SPSI()
            {
                ID = curID,
                RegisterNumber = curRegisterNumber,
                Deal = curDeal,
                Page = curPage,
                IsSp = curIsSp,
                IsDelete = curIsDelete,
                LastModified = curLastModified,
            };
            return newSPSI;
        }
    }
}
