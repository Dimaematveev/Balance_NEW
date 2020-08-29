using Balance.DAL.Interface;
using Balance.DAL.Interface.Devices;
using Balance.Model.Devices;
using Balance.Model.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL.InterfaceRealization.Devices
{
    public class PrinterRepository : GeneralDeviceRepository<Printer>, IPrinterRepository
    {

        public PrinterRepository(IDeviceCommonRepository<DeviceModel> deviceModelRepository, IDeviceCommonRepository<Location> locationRepository):base(deviceModelRepository, locationRepository)
        {
        }
        protected override string SHEMA_NAME => "dev";

        protected override string TABLE_NAME => "Printer";

        protected override Printer GetDeviceTypeFromDataReader(DbDataReader dbDataReader)
        {
            var curPagesPerMinute = (int)dbDataReader["PagesPerMinute"];

            var newDeviceModel = base.GetDeviceTypeFromDataReader(dbDataReader);
            newDeviceModel.PagesPerMinute = curPagesPerMinute;

            return newDeviceModel;
        }

        protected override List<SqlParameter> GetSqlParameters(Printer commonModel)
        {
            List<SqlParameter> sqlParameters = base.GetSqlParameters(commonModel);
            sqlParameters.Add(new SqlParameter("@PagesPerMinute", commonModel?.PagesPerMinute));
            return sqlParameters;
        }
    }
}
