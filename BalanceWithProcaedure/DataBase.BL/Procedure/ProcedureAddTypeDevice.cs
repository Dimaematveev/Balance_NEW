using DataBase.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace DataBase.BL.Procedure
{
    public class ProcedureAddTypeDevice
    {
        private TypeDevice typeDevice;
        private readonly TestProcedureContext context;

        public ProcedureAddTypeDevice(TestProcedureContext context, TypeDevice typeDevice)
        {
            this.context = context;
            this.typeDevice = typeDevice;
        }

        public void Add()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@TypeName", typeDevice.Name));
            ExecuteSqlProcedure("[dic].[Add_TypeDevice]",sqlParameters);
        }
        public void Update()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@ID", typeDevice.ID));
            sqlParameters.Add(new SqlParameter("@TypeName", typeDevice.Name));
            ExecuteSqlProcedure("[dic].[Update_TypeDevice]", sqlParameters);
        }

        private void ExecuteSqlProcedure(string nameProcedure,List<SqlParameter> sqlParameters)
        {
            string res = nameProcedure + " ";
            foreach (var item in sqlParameters)
            {
                res += item.ParameterName + ",";
            }
            res = res.TrimEnd(',');
            context.Database.ExecuteSqlCommand(res, sqlParameters.ToArray());
        }
    }
}
