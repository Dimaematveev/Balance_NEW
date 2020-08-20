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
    /// View-Model Заявки
    /// </summary>
    public class FixesViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Динамическая коллекция Заявок
        /// </summary>
        private ObservableCollection<Riparazione> fixes;
        /// <summary>
        /// Динамическая коллекция Заявок
        /// </summary>
        public ObservableCollection<Riparazione> Fixes
        {
            get { return fixes; }
            set
            {
                fixes = value;
                OnPropertyChanged("Fixes");
            }
        }
        /// <summary>
        /// Выбранная заявка
        /// </summary>
        private Riparazione selectedFix;
        /// <summary>
        /// Выбранная заявка
        /// </summary>
        public Riparazione SelectedFix
        {
            get
            {
                return selectedFix;
            }
            set
            {
                selectedFix = value;
                OnPropertyChanged("SelectedFix");
                SelectedFixCar = Cars.Where(x => x.Targa == SelectedFix.CarID).FirstOrDefault();
                SelectedMechanic = Mechanics.Where(x => x.ID == SelectedFix.MechanicID).FirstOrDefault();
            }
        }

        /// <summary>
        /// Список Механиков
        /// </summary>
        public List<Person> Mechanics { get; set; }
        /// <summary>
        /// Список Машин
        /// </summary>
        public List<Auto> Cars { get; set; }

        //TODO: не уверен
        /// <summary>
        /// Автомобиль по выбранной заявки
        /// </summary>
        private Auto selectedFixCar;
        //TODO: не уверен
        /// <summary>
        /// Автомобиль по выбранной заявки
        /// </summary>
        public Auto SelectedFixCar
        {
            get
            {
                return selectedFixCar;
            }
            set
            {
                selectedFixCar = value;
                OnPropertyChanged("SelectedFixCar");
            }
        }
        //TODO: не уверен
        /// <summary>
        /// Механик по выбранной заявки
        /// </summary>
        private Person selectedMechanic;
        //TODO: не уверен
        /// <summary>
        /// Механик по выбранной заявки
        /// </summary>
        public Person SelectedMechanic
        {
            get
            {
                return selectedMechanic;
            }
            set
            {
                selectedMechanic = value;
                OnPropertyChanged("SelectedMechanic");
                if (SelectedMechanic != null)
                    SelectedFix.MechanicID = SelectedMechanic.ID;
            }
        }

        /// <summary>
        /// Команда добавления заявки
        /// </summary>
        public ICommand AddFixCommand { get; set; }
        /// <summary>
        /// Команда сохранения заявки
        /// </summary>
        public ICommand SaveFixCommand { get; set; }


        //TODO:Не знаю как описать
        public FixesViewModel()
        {
            Fixes = new ObservableCollection<Riparazione>(App.fixDataService.GetAllFixes());
            AddFixCommand = new CustomCommand(AddFix, delegate { return true; });
            SaveFixCommand = new CustomCommand(SaveFix, delegate { return SelectedFix != null; });
            Mechanics = App.mechanicDataService.GetAllMechanics();
            Cars = App.carDataService.GetAllCars();
        }

        /// <summary>
        /// Добавление заявки
        /// </summary>
        /// <param name="obj">Не нужно</param>
        void AddFix(object obj)
        {
            SelectedFix = new Riparazione();
        }
        /// <summary>
        /// Сохранение заявки
        /// </summary>
        /// <param name="obj">Не нужно</param>
        void SaveFix(object obj)
        {
            if (SelectedFix.ID == 0)
                App.fixDataService.NewFix(SelectedFix);
            else
                App.fixDataService.UpdateFix(SelectedFix);
            Fixes = new ObservableCollection<Riparazione>(App.fixDataService.GetAllFixes());
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
