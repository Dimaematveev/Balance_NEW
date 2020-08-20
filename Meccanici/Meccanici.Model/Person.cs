using System;
using System.ComponentModel;

namespace Meccanici.Model
{
    /// <summary>
    /// Человек
    /// </summary>
    public class Person : INotifyPropertyChanged, IEditableObject
    {
        /// <summary>
        /// Вложенная структура Данные Человека
        /// </summary>
        struct PersonData
        {
            /// <summary>
            /// id Человека
            /// </summary>
            internal int id;
            /// <summary>
            /// Имя 
            /// </summary>
            internal string name;
            /// <summary>
            /// Фамилия
            /// </summary>
            internal string surname;
            /// <summary>
            /// e-mail
            /// </summary>
            internal string email;
            /// <summary>
            /// Телефон
            /// </summary>
            internal string phone;
            /// <summary>
            /// Является механиком
            /// </summary>
            internal byte isMechanic;
            /// <summary>
            /// удален?
            /// </summary>
            internal bool isDelete;
        }
        /// <summary>
        /// Данные человека
        /// </summary>
        private PersonData personData;

        /// <summary>
        /// id Человека
        /// </summary>
        public int ID
        {
            get { return personData.id; }
            set
            {
                personData.id = value;
            }
        }

        /// <summary>
        /// Имя 
        /// </summary>
        public string Name
        {
            get
            {
                return personData.name;
            }
            set
            {
                personData.name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("Initials");
            }
        }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get
            {
                return personData.surname;
            }
            set
            {
                personData.surname = value;
                OnPropertyChanged("Surname");
                OnPropertyChanged("Initials");
            }
        }
        /// <summary>
        /// e-mail
        /// </summary>
        public string Email
        {
            get
            {
                return personData.email;
            }
            set
            {
                personData.email = value;
                OnPropertyChanged("Email");
            }
        }
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone
        {
            get
            {
                return personData.phone;
            }
            set
            {
                personData.phone = value;
                OnPropertyChanged("Email");
            }
        }
        /// <summary>
        /// Является механиком
        /// </summary>
        public byte IsMechanic
        {
            get
            {
                return personData.isMechanic;
            }
            set
            {
                personData.isMechanic = value;
                OnPropertyChanged("IsMechanic");
            }
        }
        /// <summary>
        /// Удален?
        /// </summary>
        public bool IsDelete
        {
            get { return personData.isDelete; }
            set
            {
                personData.isDelete = value;
                OnPropertyChanged("IsDelete");
            }
        }
        /// <summary>
        /// Инициалы
        /// </summary>
        public string Initials
        {
            get
            {
                string res = "";
                if (!string.IsNullOrWhiteSpace(Name)) 
                {
                    res += Name.TrimStart()[0];
                }
                if (!string.IsNullOrWhiteSpace(Surname))
                {
                    res += Surname.TrimStart()[0];
                }
                return res;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Какие были данные. у человека Для интерфейса IEditableObject . нужен для отмены изменений
        /// </summary>
        private PersonData backupData;

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
                backupData = personData;
                Console.WriteLine("Started Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }
        /// <summary>
        /// Уничтожает изменения, выполненные после последнего вызова метода BeginEdit().
        /// </summary>
        public void CancelEdit()
        {
            if (isEditing)
            {
                personData = backupData;
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
                OnPropertyChanged("IsDelete");
                OnPropertyChanged("Initials");
                isEditing = false;
                Console.WriteLine("Cancelled Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }
        /// <summary>
        /// Помещает в базовый объект изменения, выполненные с момента последнего вызова метода BeginEdit() или AddNew().
        /// </summary>
        public void EndEdit()
        {
            if (isEditing)
            {
                backupData = personData;
                isEditing = false;
                Console.WriteLine("Ended Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }


        /// <summary>
        /// Выводит строку в формате: Имя Фамилия
        /// </summary>
        /// <returns>Имя Фамилия</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Surname);
        }

    }
}
