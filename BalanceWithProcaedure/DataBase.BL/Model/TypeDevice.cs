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
        /// Событие изменения
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Воспроизводит событие изменения
        /// </summary>
        /// <param name="prop"> Название Свойства которое изменилось. </param>
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
