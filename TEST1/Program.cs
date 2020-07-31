using Connected;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace TEST1
{
    class Program
    {
        static void Main()
        {
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            DataContext db = new DataContext(Connect._connetionString);
        
            // параметры
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter { ParameterName = "@ModelID", Value = 4 });
            sqlParameters.Add(new SqlParameter { ParameterName = "@SN", Value = "M11" });
            sqlParameters.Add(new SqlParameter { ParameterName = "@Year", Value = 2019 });
            sqlParameters.Add(new SqlParameter { ParameterName = "@ScreenResolution", Value = "500x500" });
            var Procedure = Connect.ExecuteProcedure("[dev].[Add_Monitor]", sqlParameters.ToArray());
            Console.WriteLine();
            Console.WriteLine("PROCEDURE: "+ Procedure);
            Console.WriteLine();
            var data = Connect.GetData("select * from dev.View_Monitor");
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
