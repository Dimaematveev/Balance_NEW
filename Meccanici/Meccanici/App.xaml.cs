using Meccanici.DAL;
using Meccanici.DAL.Interface;
using Meccanici.DAL.InterfaceRealization;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Meccanici.Model;

namespace Meccanici
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ICustomerRepository customerDataService;
        public static ICarRepository carDataService;
        public static IMechanicRepository mechanicDataService;
        public static IFixRepository fixDataService;

        public App()
        {
            new DBConnection();
            customerDataService = new CustomerRepository();
            carDataService = new CarRepository();
            mechanicDataService = new MechanicRepository();
            fixDataService = new FixRepository();
        }
    }
}
