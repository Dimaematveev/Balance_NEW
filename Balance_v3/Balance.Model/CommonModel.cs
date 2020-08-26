using System;
using System.ComponentModel;

namespace Balance.Model
{
    /// <summary>
    /// Общая модель 
    /// </summary>
    public abstract class CommonModel : INotifyPropertyChanged, IEditableObject
    {
        /// <summary>
        /// ID общей модели
        /// </summary>
        private int _ID;
        /// <summary>
        /// ID общей модели
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        /// <summary>
        /// Флаг удаления
        /// </summary>
        private bool _IsDelete;
        /// <summary>
        /// Флаг удаления
        /// </summary>
        public bool IsDelete
        {
            get { return _IsDelete; }
            set
            {
                _IsDelete = value;
                OnPropertyChanged(nameof(IsDelete));
            }
        }
        /// <summary>
        /// Время последнего изменения
        /// </summary>
        private DateTime _LastModified;
        /// <summary>
        /// Время последнего изменения
        /// </summary>
        public DateTime LastModified
        {
            get { return _LastModified; }
            set
            {
                _LastModified = value;
                OnPropertyChanged(nameof(LastModified));
            }
        }

    


        #region INotifyPropertyChanged
        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="prop">Название изменившегося свойства </param>
        protected internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Копирование
        /// <summary>
        /// Заполнить текущий объект из переданного, кроме общих свойств
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public abstract void Fill(CommonModel copy);

        /// <summary>
        /// Скопировать текущий объект в новый, кроме общих свойств
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public abstract CommonModel Clone();

        /// <summary>
        /// Заполнить текущий объект из переданного
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public void AllFill(CommonModel copy)
        {
            if (copy != null)
            {
                Fill(copy);
                ID = copy.ID;
                IsDelete = copy.IsDelete;
                LastModified = copy.LastModified;
            }

        }
        /// <summary>
        /// Скопировать текущий объект в новый
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public CommonModel AllClone()
        {
            CommonModel newCommonModel = Clone();
            newCommonModel.AllFill(this);
            return newCommonModel;
        }
        #endregion

        #region IEditableObject
        /// <summary>
        /// Объект с изначальными данными
        /// </summary>
        private CommonModel backupData;
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        private bool isEditing;
        /// <summary>
        /// Начать редактирование объекта.
        /// </summary>
        public void BeginEdit()
        {
            if (!isEditing)
            {
                isEditing = true;
                backupData = AllClone();
                //Console.WriteLine("Started Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }

        }
        /// <summary>
        /// Откат изменений, выполненных после последнего вызова метода BeginEdit().
        /// </summary>
        public void CancelEdit()
        {
            if (isEditing)
            {
                this.AllFill(backupData);
                OnPropertyChanged(null);
                isEditing = false;
                //Console.WriteLine("Cancelled Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }
        /// <summary>
        /// Помещает в базовый объект изменения, выполненные с момента последнего вызова метода BeginEdit() или AddNew().
        /// </summary>
        public void EndEdit()
        {
            if (isEditing)
            {
                backupData = AllClone();
                isEditing = false;
                //Console.WriteLine("Ended Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }
        #endregion
    }
}
