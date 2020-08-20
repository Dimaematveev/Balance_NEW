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
        /// <summary>
        /// View-Model Домашней страницы
        /// </summary>
        private static readonly HomeViewModel homeViewModel = new HomeViewModel();
        /// <summary>
        /// View-Model клиента
        /// </summary>
        private static readonly ClientiViewModel clientiViewModel = new ClientiViewModel(ClientiViewModel.RepositoryType.Customers);
        /// <summary>
        /// View-Model механика
        /// </summary>
        private static readonly ClientiViewModel meccaniciViewModel = new ClientiViewModel(ClientiViewModel.RepositoryType.Employees);
        /// <summary>
        /// View-Model автомобиля
        /// </summary>
        private static readonly AutoViewModel autoViewModel = new AutoViewModel();
        /// <summary>
        /// View-Model заявки
        /// </summary>
        private static readonly FixesViewModel fixesViewModel = new FixesViewModel();
        /// <summary>
        /// View-Model Домашней страницы
        /// </summary>
        public static HomeViewModel HomeViewModel
        {
            get
            {
                return homeViewModel;
            }
        }
        /// <summary>
        /// View-Model клиента
        /// </summary>
        public static ClientiViewModel ClientiViewModel
        {
            get
            {
                return clientiViewModel;
            }
        }

       
        /// <summary>
        /// View-Model механика
        /// </summary>
        public static ClientiViewModel MeccaniciViewModel
        {
            get
            {
                return meccaniciViewModel;
            }
        }
        /// <summary>
        /// View-Model автомобиля
        /// </summary>
        public static AutoViewModel AutoViewModel
        {
            get
            {
                return autoViewModel;
            }
        }
        /// <summary>
        /// View-Model заявки
        /// </summary>
        public static FixesViewModel FixesViewModel
        {
            get
            {
                return fixesViewModel;
            }
        }
    }
}
