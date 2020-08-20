using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meccanici.Model
{
    /// <summary>
    /// Класс Автомобиль
    /// </summary>
    public class Auto : INotifyPropertyChanged, IEditableObject
    {
        /// <summary>
        /// Вложенная структура Данные машины
        /// </summary>
        struct CarData
        {
            /// <summary>
            /// Марка машины
            /// </summary>
            internal string marca;
            /// <summary>
            /// Модель машины
            /// </summary>
            internal string modello;
            /// <summary>
            /// Номерной знак
            /// </summary>
            internal string targa;
            /// <summary>
            /// год
            /// </summary>
            internal int anno;
            /// <summary>
            /// Id клиента
            /// </summary>
            internal int id_Cliente;
        }

      
        /// <summary>
        /// Данные машины
        /// </summary>
        private CarData carData;
        /// <summary>
        /// Марка машины
        /// </summary>
        public string Marca
        {
            get { return carData.marca; }
            set
            {
                carData.marca = value;
                OnPropertyChanged("Marca");
            }
        }
        /// <summary>
        /// Модель машины
        /// </summary>
        public string Modello
        {
            get { return carData.modello; }
            set
            {
                carData.modello = value;
                OnPropertyChanged("Modello");
            }
        }
        /// <summary>
        /// Номерной знак
        /// </summary>
        public string Targa
        {
            get { return carData.targa; }
            set
            {
                carData.targa = value;
                OnPropertyChanged("Targa");
            }
        }
        /// <summary>
        /// год
        /// </summary>
        public int Anno
        {
            get { return carData.anno; }
            set
            {
                carData.anno = value;
                OnPropertyChanged("Anno");
            }
        }
        /// <summary>
        /// Id клиента
        /// </summary>
        public int ID_Cliente
        {
            get { return carData.id_Cliente; }
            set
            {
                carData.id_Cliente = value;
                OnPropertyChanged("ID_Cliente");
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

        /// <summary>
        /// Какие были данные у машины. Для интерфейса IEditableObject . нужен для отмены изменений
        /// </summary>
        private CarData backupData;
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        private bool isEditing;
        /// <summary>
        /// Начинает редактирование объекта.
        /// </summary>
        public void BeginEdit()
        {
            if (!isEditing)
            {
                isEditing = true;
                backupData = carData;
                Console.WriteLine("Started Editing Car {0}", Targa);
            }
        }
        /// <summary>
        /// Уничтожает изменения, выполненные после последнего вызова метода BeginEdit().
        /// </summary>
        public void CancelEdit()
        {
            if (isEditing)
            {
                carData = backupData;
                OnPropertyChanged("Targa");
                OnPropertyChanged("Anno");
                OnPropertyChanged("Marca");
                OnPropertyChanged("ID_Cliente");
                OnPropertyChanged("Modello");
                isEditing = false;
                Console.WriteLine("Cancelled Editing Car {0}", Targa);
            }
        }
        /// <summary>
        /// Помещает в базовый объект изменения, выполненные с момента последнего вызова метода BeginEdit() или AddNew().
        /// </summary>
        public void EndEdit()
        {
            if (isEditing)
            {
                backupData = carData;
                isEditing = false;
                Console.WriteLine("Ended Editing Customer Car {0}", Targa);
            }
        }

        /// <summary>
        /// Выводит строку в формате: Номерной_знак
        /// </summary>
        /// <returns>Номерной_знак</returns>
        public override string ToString()
        {
            return carData.targa;
        }
    }
}
