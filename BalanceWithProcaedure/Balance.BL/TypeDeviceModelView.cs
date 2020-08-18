using DataBase.BL;
using DataBase.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Balance.BL
{
    public class TypeDeviceModelView : INotifyPropertyChanged
    {
        private readonly TestProcedureContext Context;
        private IEnumerable<TypeDevice> typeDevices;
        public IEnumerable<TypeDevice> TypeDevices
        {
            get { return typeDevices; }
            set
            {
                typeDevices = value;
                OnPropertyChanged(nameof(TypeDevices));
            }
        }
        public TypeDeviceModelView()
        {
            Context = new TestProcedureContext();
            Context.TypeDevices.Load();
            typeDevices = Context.TypeDevices.Local.ToBindingList();

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
