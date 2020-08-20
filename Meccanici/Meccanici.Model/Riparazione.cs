using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meccanici.Model
{
    /// <summary>
    /// Ремонт?? заяка по ремонту?
    /// </summary>
    public class Riparazione : INotifyPropertyChanged
    {
        /// <summary>
        /// ID ремонта
        /// </summary>
        private int id;
        /// <summary>
        /// id механика
        /// </summary>
        private int mechanicID;
        /// <summary>
        /// id Машины
        /// </summary>
        private string carID;
        /// <summary>
        /// Заметка
        /// </summary>
        private string note;
        /// <summary>
        /// Дата и время заявки
        /// </summary>
        private DateTime date;
        public Riparazione()
        {
            date = DateTime.Today;
        }
        /// <summary>
        /// ID ремонта
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }
        /// <summary>
        /// id механика
        /// </summary>
        public int MechanicID
        {
            get { return mechanicID; }
            set
            {
                mechanicID = value;
                OnPropertyChanged("MechanicID");
            }
        }
        /// <summary>
        /// id Машины
        /// </summary>
        public string CarID
        {
            get { return carID; }
            set
            {
                carID = value;
                OnPropertyChanged("CarID");
            }
        }
        /// <summary>
        /// Заметка
        /// </summary>
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged("Note");
            }
        }
        /// <summary>
        /// Дата и время заявки
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="prop">Изменившееся свойство </param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
