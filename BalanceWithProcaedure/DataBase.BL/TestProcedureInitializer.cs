using DataBase.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase.BL
{
    public class TestProcedureInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TestProcedureContext>
    {
        protected override void Seed(TestProcedureContext context)
        {
            List<TypeDevice> typeDevices = new List<TypeDevice>()
            {
                new TypeDevice(){Name="Printer1"},
                new TypeDevice(){Name="Printer2"},
                new TypeDevice(){Name="Printer3"},
                new TypeDevice(){Name="Monitor1"},
                new TypeDevice(){Name="Monitor2"},
                new TypeDevice(){Name="Monitor3"},
            };
            context.TypeDevices.AddRange(typeDevices);
            context.SaveChanges();
           
        }
    }
}
