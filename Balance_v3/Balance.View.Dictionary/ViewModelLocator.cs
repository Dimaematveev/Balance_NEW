using Balance.View.Dictionary.ViewModels;
using Balance.ViewModel.Dictionary.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Balance.View.Dictionary
{
    /// <summary>
    /// View-Model абстракция всей системы
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// ViewModel Домашней страницы
        /// </summary>
        private static HomeViewModel homeViewModel = null;
        /// <summary>
        /// ViewModel Типов устройств
        /// </summary>
        private static DeviceTypeViewModel deviceTypeViewModel = null;
        /// <summary>
        /// ViewModel Моделей устройств
        /// </summary>
        private static DeviceModelViewModel deviceModelViewModel = null;
        /// <summary>
        /// ViewModel Названия таблиц
        /// </summary>
        private static DeviceGadgetViewModel deviceGadgetViewModel = null;
        /// <summary>
        /// ViewModel Местоположений
        /// </summary>
        private static LocationViewModel locationViewModel = null;
        /// <summary>
        /// ViewModel СП и СИ
        /// </summary>
        private static SPSIViewModel sPSIViewModel = null;

        public ViewModelLocator()
        {
            //Простое решение — проверять, не бежим ли мы в дизайнере.
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            homeViewModel = new HomeViewModel();
            deviceTypeViewModel = new DeviceTypeViewModel(App.deviceTypeDataService, App.deviceGadgetDataService);
            deviceModelViewModel = new DeviceModelViewModel(App.deviceModelRepository, App.deviceTypeDataService);
            deviceGadgetViewModel = new DeviceGadgetViewModel(App.deviceGadgetDataService);
            locationViewModel = new LocationViewModel(App.locationRepository);
            sPSIViewModel = new SPSIViewModel(App.SPSIRepository);


        }
        /// <summary>
        /// ViewModel Домашней страницы
        /// </summary>
        public static HomeViewModel HomeViewModel
        {
            get
            {
                return homeViewModel;
            }
        }
        /// <summary>
        /// ViewModel  Типов устройств
        /// </summary>
        public static DeviceTypeViewModel DeviceTypeViewModel
        {
            get
            {
                return deviceTypeViewModel;
            }
        }
        /// <summary>
        /// ViewModel  Моделей устройств
        /// </summary>
        public static DeviceModelViewModel DeviceModelViewModel
        {
            get
            {
                return deviceModelViewModel;
            }
        }
        /// <summary>
        /// ViewModel Названия таблиц
        /// </summary>
        public static DeviceGadgetViewModel DeviceGadgetViewModel
        {
            get
            {
                return deviceGadgetViewModel;
            }
        }
        /// <summary>
        /// ViewModel Местоположений
        /// </summary>
        public static LocationViewModel LocationViewModel
        {
            get
            {
                return locationViewModel;
            }
        }
        /// <summary>
        /// ViewModel СП и СИ
        /// </summary>
        public static SPSIViewModel SPSIViewModel
        {
            get
            {
                return sPSIViewModel;
            }
        }
    }
}
