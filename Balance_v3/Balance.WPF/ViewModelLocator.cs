using Balance.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Balance.WPF
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
            deviceTypeViewModel = new DeviceTypeViewModel();
            deviceModelViewModel = new DeviceModelViewModel();
            deviceGadgetViewModel = new DeviceGadgetViewModel();
            locationViewModel = new LocationViewModel();
            sPSIViewModel = new SPSIViewModel();

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
