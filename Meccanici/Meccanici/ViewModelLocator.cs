using Meccanici.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Meccanici.Model;
using Meccanici.DAL.Interface;

namespace Meccanici
{

    /// <summary>
    /// View-Model абстракция всей системы
    /// </summary>
    public class ViewModelLocator
    {
        private static HomeViewModel homeViewModel = null;
        private static ClientiViewModel clientiViewModel = null;
        private static ClientiViewModel meccaniciViewModel = null;
        private static AutoViewModel autoViewModel = null;
        private static FixesViewModel fixesViewModel = null;

        public ViewModelLocator()
        {
            homeViewModel = new HomeViewModel();
            clientiViewModel = new ClientiViewModel(ClientiViewModel.RepositoryType.Customers);
            meccaniciViewModel = new ClientiViewModel(ClientiViewModel.RepositoryType.Employees);
            autoViewModel = new AutoViewModel();
            fixesViewModel = new FixesViewModel();
    }

        public static HomeViewModel HomeViewModel
        {
            get
            {
                return homeViewModel;
            }
        }

        public static ClientiViewModel ClientiViewModel
        {
            get
            {
                return clientiViewModel;
            }
        }

        public static AutoViewModel AutoViewModel
        {
            get
            {
                return autoViewModel;
            }
        }

        public static ClientiViewModel MeccaniciViewModel
        {
            get
            {
                return meccaniciViewModel;
            }
        }
        public static FixesViewModel FixesViewModel
        {
            get
            {
                return fixesViewModel;
            }
        }

    }
}
