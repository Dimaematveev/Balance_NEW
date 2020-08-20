﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Balance.Model
{
    /// <summary>
    /// Общая модель 
    /// </summary>
    public abstract class CommonModel : INotifyPropertyChanged, IEditableObject
    {
        internal int _ID;
        public abstract int ID { get; set; }
        internal bool _IsDelete;
        public abstract bool IsDelete { get; set; }


        #region INotifyPropertyChanged
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
        #endregion

        #region Копирование
        private CommonModel backupData;
        public abstract void Fill(CommonModel copy);
        public abstract CommonModel Clone();
        #endregion

        #region IEditableObject
        /// <summary>
        /// Показывает находится ли сейчас объект на редактировании. То есть можно-ли сохранить или отменить изменения
        /// </summary>
        private bool isEditing;
        /// <summary>
        /// Начинает редактирование объекта.
        /// </summary>
        public  void BeginEdit()
        {
            if (!isEditing)
            {
                isEditing = true;
                backupData = Clone();
                backupData._ID = _ID;
                backupData._IsDelete = _IsDelete;
                //Console.WriteLine("Started Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
            
        }
        /// <summary>
        /// Уничтожает изменения, выполненные после последнего вызова метода BeginEdit().
        /// </summary>
        public void CancelEdit()
        {
            if (isEditing)
            {
                this.Fill(backupData);
                _ID = backupData._ID;
                _IsDelete = backupData._IsDelete;
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
                backupData = Clone();
                backupData._ID = _ID;
                backupData._IsDelete = _IsDelete;
                isEditing = false;
                //Console.WriteLine("Ended Editing Customer ({0} {1}) with ID {2}", Name, Surname, ID);
            }
        }
        #endregion
    }
}