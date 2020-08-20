using Meccanici.DAL;
using Meccanici.DAL.InterfaceRealization;
using Meccanici.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main()
        {
            _ = new DBConnection();
            DBConnection.instance.Connect();
            var res = DBConnection.instance.ExecuteQuery("SELECT * FROM Person WHERE IsMechanic=1");
          
            while (res.Read())
            {
                Console.WriteLine((string)res["Name"]);
                  
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
