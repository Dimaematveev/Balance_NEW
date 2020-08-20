using Meccanici.DAL;
using Meccanici.DAL.Interface;
using Meccanici.DAL.InterfaceRealization;
using System.Windows;

namespace Meccanici
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        readonly DBConnection dbConnection = new DBConnection();
        public static ICustomerRepository customerDataService = new CustomerRepository();
        public static ICarRepository carDataService = new CarRepository();
        public static IMechanicRepository mechanicDataService = new MechanicRepository();
        public static IFixRepository fixDataService = new FixRepository();
    }
}
