using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataBase.BL.Model
{
    [Table("dic.Type_Device")]
    public class TypeDevice: INotifyPropertyChanged
    {
        private int _ID;
        private string _Name;
        public int ID 
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        [Required]
        [StringLength(50)]
        public string Name { 
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Скопировать текущий объект в новый
        /// </summary>
        /// <returns>Новый объект с такими-же свойствами</returns>
        public object Clone()
        {
            TypeDevice newTypeDevice = new TypeDevice();
            newTypeDevice.Fill(this);
            return newTypeDevice;
        }

        /// <summary>
        /// Заполнить текущий объект из переданного
        /// </summary>
        /// <param name="copy">переданный объект</param>
        public void Fill(object copy)
        {
            if (copy != null && copy is TypeDevice copyDeviceType)
            {
                Name = copyDeviceType.Name;
            }
        }

        /// <summary>Событие для извещения об изменения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="prop">Изменившееся свойство </param>

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
