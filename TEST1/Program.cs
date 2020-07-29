using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Connected;

namespace TEST1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var connect = new Connect();
            // параметры
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@ModelID", Value = 4 });
            sqlParameters.Add(new SqlParameter { ParameterName = "@SN", Value = "M11" });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Year", Value = 2019 });
            sqlParameters.Add(new SqlParameter { ParameterName = "@ScreenResolution", Value = "500x500" });
            var Procedure = connect.ExecuteProcedure("[dev].[Add_Monitor]", sqlParameters.ToArray());
            Console.WriteLine();
            Console.WriteLine("PROCEDURE: "+ Procedure);
            Console.WriteLine();
            var data = connect.GetData("select * from dev.View_Monitor");
            foreach (DataColumn item in data.Columns)
            {
                Console.Write(item.ColumnName);
                Console.Write(" | ");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-',50));
            foreach (DataRow item in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    Console.Write(item[i]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
