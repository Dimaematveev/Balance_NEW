using Balance.DAL;
using Balance.DAL.Interface;
using Balance.DAL.InterfaceRealization.Dictionaries;
using Balance.Model.Dictionaries;
using System.Windows;

namespace Balance.View.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IDeviceCommonRepository<DeviceType> deviceGadgetDataService;
        public static IDeviceCommonRepository<DeviceType> deviceTypeDataService;
        public static IDeviceCommonRepository<DeviceModel> deviceModelRepository;
        public static IDeviceCommonRepository<Location> locationRepository;
        public static IDeviceCommonRepository<SPSI> SPSIRepository;
        public App()
        {
            new DBConnection();
            deviceGadgetDataService = new DeviceGadgetRepository();
            deviceTypeDataService = new DeviceTypeRepository(deviceGadgetDataService);
            deviceModelRepository = new DeviceModelRepository(deviceTypeDataService);
            locationRepository = new LocationRepository();
            SPSIRepository = new SPSIRepository();
        }
    }
}
