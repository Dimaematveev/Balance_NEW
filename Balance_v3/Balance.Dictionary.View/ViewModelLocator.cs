using Balance.Dictionary.View.ViewModel;
using System.ComponentModel;
using System.Windows;

namespace Balance.Dictionary.View
{
    /// <summary>
    /// View-Model абстракция всей системы
    /// </summary>
    public class ViewModelLocator
    {
        private static HomeViewModel homeViewModel = null;
        private static DeviceTypeViewModel deviceTypeViewModel = null;
        private static DeviceModelViewModel deviceModelViewModel = null;
        private static DeviceGadgetViewModel deviceGadgetViewModel = null;
        private static LocationViewModel locationViewModel = null;
        private static SPSIViewModel sPSIViewModel = null;

        public ViewModelLocator()
        {
            //Простое решение — проверять, не бежим ли мы в дизайнере.
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            homeViewModel = new HomeViewModel();
            deviceTypeViewModel = new DeviceTypeViewModel(App.deviceTypeDataService,App.deviceGadgetDataService);
            deviceModelViewModel = new DeviceModelViewModel(App.deviceModelRepository, App.deviceTypeDataService);
            deviceGadgetViewModel = new DeviceGadgetViewModel(App.deviceGadgetDataService);
            locationViewModel = new LocationViewModel(App.locationRepository);
            sPSIViewModel = new SPSIViewModel(App.SPSIRepository);

        }

        public static HomeViewModel HomeViewModel
        {
            get
            {
                return homeViewModel;
            }
        }
        public static DeviceTypeViewModel DeviceTypeViewModel
        {
            get
            {
                return deviceTypeViewModel;
            }
        }
        public static DeviceModelViewModel DeviceModelViewModel
        {
            get
            {
                return deviceModelViewModel;
            }
        }
        public static DeviceGadgetViewModel DeviceGadgetViewModel
        {
            get
            {
                return deviceGadgetViewModel;
            }
        }
        public static LocationViewModel LocationViewModel
        {
            get
            {
                return locationViewModel;
            }
        }
        public static SPSIViewModel SPSIViewModel
        {
            get
            {
                return sPSIViewModel;
            }
        }
    }
}
