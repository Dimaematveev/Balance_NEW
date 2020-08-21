using Meccanici.Model;
using Meccanici.Utility;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Meccanici.ViewModel
{
    /// <summary>
    /// View-Model Автомобиля
    /// </summary>
    public class AutoViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Динамическая коллекция Машин
        /// </summary>
        private ObservableCollection<Auto> cars;

        /// <summary>
        /// Динамическая коллекция Машин
        /// </summary>
        public ObservableCollection<Auto> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
                OnPropertyChanged("Cars");
            }
        }
        /// <summary>
        /// Динамическая коллекция отфильтрованных Машин
        /// </summary>
        private ObservableCollection<Auto> filteredCars;

        /// <summary>
        /// Динамическая коллекция отфильтрованных Машин
        /// </summary>
        public ObservableCollection<Auto> FilteredCars
        {
            get
            {
                return filteredCars ?? Cars;
            }
            set
            {
                filteredCars = value;
                SelectedCar = filteredCars.FirstOrDefault();
                OnPropertyChanged("FilteredCars");
            }
        }
        
        /// <summary>
        /// Выбранная машина
        /// </summary>
        private Auto selectedCar;
        /// <summary>
        /// Выбранная машина
        /// </summary>
        public Auto SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
                SelectedCarCustomer = Clienti.Where(x => x.ID == SelectedCar.ID_Cliente).FirstOrDefault();
                SelectedCarFixes = new ObservableCollection<Riparazione>(App.fixDataService.GetCarFixes(SelectedCar.Targa));
            }
        }
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        private Person selectedCarCustomer;
        /// <summary>
        /// Клиент выбранной машины
        /// </summary>
        public Person SelectedCarCustomer
        {
            get { return selectedCarCustomer; }
            set
            {
                selectedCarCustomer = value;
                OnPropertyChanged("SelectedCarCustomer");
            }
        }
        /// <summary>
        /// Список клиентов
        /// </summary>
        public List<Person> Clienti
        {
            get; set;
        }
        /// <summary>
        /// Динамическая коллекция Заявок на ремонт
        /// </summary>
        private ObservableCollection<Riparazione> selectedCarFixes;
        /// <summary>
        /// Динамическая коллекция Заявок на ремонт
        /// </summary>
        public ObservableCollection<Riparazione> SelectedCarFixes
        {
            get { return selectedCarFixes; }
            set
            {
                selectedCarFixes = value;
                OnPropertyChanged("SelectedCarFixes");
            }
        }
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
                OnPropertyChanged("IsEditing");
            }
        }
        /// <summary>
        /// Команда добавления Машины
        /// </summary>
        public ICommand AddCarCommand { get; set; }
        /// <summary>
        /// Команда Сохранения Машины
        /// </summary>
        public ICommand SaveCarCommand { get; set; }
        /// <summary>
        /// Команда Удаления Машины
        /// </summary>
        public ICommand DeleteCarCommand { get; set; }

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
                FilteredCars = new ObservableCollection<Auto>(Cars.Where(x =>
                x.Marca.ToLower().Contains(SearchString) ||
                x.Modello.ToLower().Contains(SearchString) ||
                x.Targa.ToLower().Contains(SearchString) ||
                x.Anno.ToString().Contains(SearchString)));
                OnPropertyChanged("SearchString");
            }
        }

        /// <summary>
        /// Выбрать новую машину
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void NewCar(object obj)
        {
            SelectedCar = new Auto();
            IsEditing = true;
        }
        /// <summary>
        /// Сохранить машину
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void SaveCar(object obj)
        {
            SelectedCar.ID_Cliente = SelectedCarCustomer.ID;
            SelectedCar.EndEdit();
            IsEditing = false;
            if (!Cars.Contains(SelectedCar))
            {
                App.carDataService.NewCar(SelectedCar);
                Cars.Add(SelectedCar);
            }
        }
        /// <summary>
        /// Удалить выбранную машину
        /// </summary>
        /// <param name="obj">Не нужно</param>
        private void DeleteCar(object obj)
        {
            App.carDataService.DeleteCar(SelectedCar);
            SelectedCar = new Auto();
        }

        //TODO:не знаю что написать
        public AutoViewModel()
        {
            Cars = new ObservableCollection<Auto>(App.carDataService.GetAllCars());
            AddCarCommand = new CustomCommand(NewCar, delegate { return true; });
            SaveCarCommand = new CustomCommand(SaveCar, delegate { return IsEditing; });
            DeleteCarCommand = new CustomCommand(DeleteCar, delegate { return SelectedCar != null; });
            Clienti = App.customerDataService.GetAllCustomers();
        }

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
