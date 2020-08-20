﻿using Balance.DAL;
using Balance.DAL.Interface;
using Balance.DAL.InterfaceRealization;
using Balance.WPF.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Balance.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IDeviceTypeRepository deviceTypeDataService;
        public App()
        {
            new DBConnection();
            deviceTypeDataService = new DeviceTypeRepository();
        }
    }
}