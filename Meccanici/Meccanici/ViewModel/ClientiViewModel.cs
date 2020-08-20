using Meccanici.Model;
using Meccanici.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Meccanici.ViewModel
{
    /// <summary>
    /// View-Model Клиента
    /// </summary>
    public class ClientiViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Динамическая коллекция Клиентов
        /// </summary>
        private ObservableCollection<Person> clienti;
        /// <summary>
        /// Динамическая коллекция Клиентов
        /// </summary>
        public ObservableCollection<Person> Customers
        {
            get { return clienti; }
            set
            {
                clienti = value;
                OnPropertyChanged("Customers");
            }
        }
        /// <summary>
        /// Динамическая коллекция отфильтрованных Клиентов
        /// </summary>
        private ObservableCollection<Person> filteredCustomers;
        /// <summary>
        /// Динамическая коллекция отфильтрованных Клиентов
        /// </summary>
        public ObservableCollection<Person> FilteredCustomers
        {
            get { return filteredCustomers ?? Customers; }
            set
            {
                filteredCustomers = value;
                SelectedCustomer = filteredCustomers.FirstOrDefault();
                OnPropertyChanged("FilteredCustomers");
            }
        }
        /// <summary>
        /// Выбранный клиент
        /// </summary>
        private Person selectedCustomer;
        /// <summary>
        /// Выбранный клиент
        /// </summary>
        public Person SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                if (value != null && CurrentRepo == RepositoryType.Customers)
                    SelectedCustomerCars = App.carDataService.GetCustomerCars(SelectedCustomer.ID);
                else
                    SelectedCustomerCars = null;
                IsEditing = false;
                OnPropertyChanged("SelectedCustomer");
            }
        }
        /// <summary>
        /// Список автомобилей выбранного клиента
        /// </summary>
        private List<Auto> selectedCustomerCars;
        /// <summary>
        /// Список автомобилей выбранного клиента
        /// </summary>
        public List<Auto> SelectedCustomerCars
        {
            get
            {
                return selectedCustomerCars;
            }
            set
            {
                selectedCustomerCars = value;
                OnPropertyChanged("SelectedCustomerCars");
            }
        }

        //TODO: Не понимаю
        /// <summary>
        /// Редактирование анимации??
        /// </summary>
        public Action editingAnimation;

        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        private bool isEditing;
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        public bool IsEditing
        {
            get { return isEditing; }
            set
            {
                isEditing = value;
                if (IsEditing)
                    CurrentEditIcon = "";
                else
                    CurrentEditIcon = "";
                OnPropertyChanged("IsEditing");
                editingAnimation?.Invoke();
            }
        }

        /// <summary>
        /// Команда добавления Клиента
        /// </summary>
        public ICommand AddCustomerCommand { get; set; }
        /// <summary>
        /// Команда редактирования
        /// </summary>
        public ICommand EditCommand { get; set; }
        /// <summary>
        /// Команда сохранения
        /// </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary>
        /// Команда удаления
        /// </summary>
        public ICommand DeleteCommand { get; set; }

        //TODO:Не понимаю
        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        private string currentEditIcon = "";
        //TODO:Не понимаю
        /// <summary>
        /// текущий значок редактирования
        /// </summary>
        public string CurrentEditIcon
        {
            get { return currentEditIcon; }
            set
            {
                currentEditIcon = value;
                OnPropertyChanged("CurrentEditIcon");
            }
        }
        /// <summary>
        /// Изменение Клиента
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void EditCustomer(object obj)
        {
            IsEditing = !IsEditing;
            if (!IsEditing)
                SelectedCustomer.CancelEdit();
            else
                SelectedCustomer.BeginEdit();
        }

        /// <summary>
        /// Сохранение клиента
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void SaveCustomer(object obj)
        {
            SelectedCustomer.EndEdit();
            IsEditing = false;
            if (!Customers.Contains(SelectedCustomer))
            {
                if (CurrentRepo == RepositoryType.Customers)
                    App.customerDataService.NewCustomer(SelectedCustomer);
                else if (CurrentRepo == RepositoryType.Employees)
                    App.mechanicDataService.NewEmployee(SelectedCustomer);
                Customers.Add(SelectedCustomer);
            }
        }
        /// <summary>
        /// Новый клиент
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void NewCustomer(object obj)
        {
            SelectedCustomer = new Person();
            IsEditing = true;
        }

        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void DeleteCustomer(object obj)
        {
            App.customerDataService.DeleteCustomer(SelectedCustomer);
            Customers.Remove(SelectedCustomer);
            //SelectedCustomer = Clienti.FirstOrDefault();
            IsEditing = false;
        }

        /// <summary>
        /// Можно ли редактировать клиента
        /// </summary>
        /// <param name="obj">Не нужно</param>
        /// <returns>true можно, false нельзя</returns>
        private bool CanEditCustomer(object obj)
        {
            return SelectedCustomer != null;
        }

        /// <summary>
        /// Можно ли сохранить клиента
        /// </summary>
        /// <param name="obj">Не нужно</param>
        /// <returns>true можно, false нельзя</returns>
        private bool CanSaveCustomer(object obj)
        {
            return IsEditing;

        }

        /// <summary>
        /// Можно ли удалить клиента
        /// </summary>
        /// <param name="obj">Не нужно</param>
        /// <returns>true можно, false нельзя</returns>
        private bool CanDeleteCustomer(object obj)
        {
            return Customers.Contains(SelectedCustomer) && IsEditing;
        }

        //TODO:Не уверен
        /// <summary>
        /// Поисковая строка
        /// </summary>
        private string searchString;
        //TODO:Не уверен
        /// <summary>
        /// Поисковая строка
        /// </summary>
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value.ToLower();
                FilteredCustomers = new ObservableCollection<Person>(Customers.Where(x =>
                x.Name.ToLower().Contains(SearchString) ||
                x.Surname.ToLower().Contains(SearchString)));
                OnPropertyChanged("SearchString");
            }
        }

        /// <summary>
        /// Присвоить значения командам
        /// </summary>
        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditCustomer, CanEditCustomer);
            SaveCommand = new CustomCommand(SaveCustomer, CanSaveCustomer);
            DeleteCommand = new CustomCommand(DeleteCustomer, CanDeleteCustomer);
            AddCustomerCommand = new CustomCommand(NewCustomer, delegate { return true; });
        }

        //TODO:не знаю что написать
        public ClientiViewModel(RepositoryType v)
        {
            if (v == RepositoryType.Customers)
                Customers = new ObservableCollection<Person>(App.customerDataService.GetAllCustomers());
            else if (v == RepositoryType.Employees)
                Customers = new ObservableCollection<Person>(App.mechanicDataService.GetAllMechanics());
            CurrentRepo = v;
            LoadCommands();
        }

        /// <summary>
        /// Перечисление Тип хранилища
        /// </summary>
        public enum RepositoryType
        {
            Customers, Employees
        }
        /// <summary>
        /// Текущее хранилище
        /// </summary>
        public RepositoryType CurrentRepo { get; set; }

        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="prop">Изменившееся свойство </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
