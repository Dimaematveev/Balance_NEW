using Balance.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.WPF
{
    /// <summary>
    /// View-Model абстракция всей системы
    /// </summary>
    public class ViewModelLocator
    {
        private static HomeViewModel homeViewModel = null;
        private static DeviceTypeViewModel deviceTypeViewModel = null;

        public ViewModelLocator()
        {
            homeViewModel = new HomeViewModel();
            deviceTypeViewModel = new DeviceTypeViewModel();
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

    }
}
