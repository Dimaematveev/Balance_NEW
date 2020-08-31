using Balance.Model.Devices;
using Balance.View.Device.ViewModels;
using Balance.View.Dictionary.ViewModels;
using Balance.ViewModel.Device.ViewModels;
using Balance.ViewModel.Dictionary.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Balance.View.Device
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
        /// ViewModel общего устройства
        /// </summary>
        private static GeneralDeviceViewModel generalDeviceViewModel = null;

        public ViewModelLocator()
        {
            //Простое решение — проверять, не бежим ли мы в дизайнере.
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            homeViewModel = new HomeViewModel();
            generalDeviceViewModel = new GeneralDeviceViewModel(App.deviceTypeDataService, App.deviceGadgetDataService);


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
        /// ViewModel общего устройства
        /// </summary>
        public static GeneralDeviceViewModel GeneralDeviceViewModel
        {
            get
            {
                return generalDeviceViewModel;
            }
        }
    }
}
