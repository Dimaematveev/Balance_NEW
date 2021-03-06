﻿using Balance.DAL.Interface.Dictionaries;
using Balance.Model.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization.Dictionaries
{
    /// <summary>
    /// Хранилище СП и СИ
    /// </summary>
    public class SPSIRepository : MyDeviceCommonRepository<SPSI>, ISPSIRepository
    {
        protected override string SHEMA_NAME => "dic";

        protected override string TABLE_NAME => "SPSI";



        protected override List<SqlParameter> GetSqlParameters(SPSI commonModel)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@RegisterNumber", commonModel?.RegisterNumber),
                new SqlParameter("@Deal", commonModel?.Deal),
                new SqlParameter("@Page", commonModel?.Page),
                new SqlParameter("@IsSp", commonModel?.IsSp),
            };
            return sqlParameters;
        }



        protected override SPSI GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curID = (int)dbDataReader["ID"];
            var curRegisterNumber = (string)dbDataReader["RegisterNumber"];
            var curDeal = dbDataReader["Deal"] as string;
            var curPage = dbDataReader["Page"] as string;
            var curIsSp = dbDataReader["IsSp"] as bool?;
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
