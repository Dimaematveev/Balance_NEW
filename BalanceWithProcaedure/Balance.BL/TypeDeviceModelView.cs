using DataBase.BL;
using DataBase.BL.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Balance.BL
{
    public class TypeDeviceModelView : INotifyPropertyChanged
    {
        private readonly TestProcedureContext Context;
        private IEnumerable<TypeDevice> typeDevices;
        private TypeDevice selectTypeDevice;
        public IEnumerable<TypeDevice> TypeDevices
        {
            get { return typeDevices; }
            set
            {
                typeDevices = value;
                OnPropertyChanged(nameof(TypeDevices));
            }
        }
        public TypeDevice SelectTypeDevice
        {
            get { return selectTypeDevice; }
            set
            {
                selectTypeDevice = value;
                OnPropertyChanged(nameof(SelectTypeDevice));
            }
        }
        /// <summary> Приватная Команда добавление </summary>
        private RelayCommand addCommand;

        /// <summary> Команда добавления </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(
                      (execute) =>
                      {
                          var window = ((IWindowFactory)execute).CreateNewWindow();
                          SelectTypeDevice = new TypeDevice();
                          window.DataContext = SelectTypeDevice;
                          if (window.ShowDialog().Value)
                          {
                              Context.TypeDevices.Add(SelectTypeDevice);
                              Context.SaveChanges();
                          }
                          else
                          {
                              SelectTypeDevice = null;
                          }
                         
                      },
                      (isCanExecute) =>
                      {
                          return true;
                      }
                  ));
            }
        }
        /// <summary> Приватная Команда добавление </summary>
        private RelayCommand editCommand;

        /// <summary> Команда добавления </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand(
                      (execute) =>
                      {
                          var window = ((IWindowFactory)execute).CreateNewWindow();
                          var oldTypeDevice = SelectTypeDevice.Clone();
                          window.DataContext = SelectTypeDevice;
                          if (window.ShowDialog().Value)
                          {
                              Context.SaveChanges();
                          }
                          else
                          {
                              SelectTypeDevice.Fill(oldTypeDevice);
                          }
                      },
                      (isCanExecute) =>
                      {
                          return SelectTypeDevice == null ? false : true;
                      }
                  ));
            }
        }
        
        public TypeDeviceModelView()
        {
            Context = new TestProcedureContext();
            Context.TypeDevices.Load();
            TypeDevices = Context.TypeDevices.Local.ToBindingList();

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
