using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Balance.DB;

namespace Test.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            using (BalanceEntities db = new BalanceEntities())
            {
                var Devices = db.Devices.Take(10);

                foreach (Device d in Devices)
                {
                    Console.WriteLine("{0}", d.SerialNumber);
                }
            }

            Console.WriteLine("");
            Console.WriteLine("ALL!!");
            Console.ReadLine();
        }
    }
}
