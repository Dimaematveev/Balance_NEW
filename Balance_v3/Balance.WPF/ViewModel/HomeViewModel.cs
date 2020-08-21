using Balance.WPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Balance.WPF.ViewModel
{
    /// <summary>
    /// View-Model Домашней страницы
    /// </summary>
    public class HomeViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Динамическая коллекция вкладок
        /// </summary>
        private ObservableCollection<Tab> tabs;
        /// <summary>
        /// Динамическая коллекция вкладок
        /// </summary>
        public ObservableCollection<Tab> Tabs
        {
            get { return tabs; }
            set
            {
                tabs = value;
                OnPropertyChanged(nameof(Tabs));
            }
        }
        /// <summary>
        /// Выбранная вкладка
        /// </summary>
        private Tab selectedTab;
        /// <summary>
        /// Выбранная вкладка
        /// </summary>
        public Tab SelectedTab
        {
            get { return selectedTab; }
            set
            {
                selectedTab = value;
                OnPropertyChanged(nameof(SelectedTab));
                LoadFrame();
            }
        }
        /// <summary>
        /// Страница выбранной вкладки
        /// </summary>
        private Page tabPage;
        /// <summary>
        /// Страница выбранной вкладки
        /// </summary>
        public Page TabPage
        {
            get { return tabPage; }
            set
            {
                tabPage = value;
                OnPropertyChanged(nameof(TabPage));
            }
        }

        /// <summary>
        /// Загрузить Страницу по Вкладке
        /// </summary>
        void LoadFrame()
        {
            switch (SelectedTab.Title)
            {
                case "Типы устройств":
                    TabPage = new DeviceTypeView();
                    break;
                default:
                    TabPage = new Page();
                    break;
            }
        }

        //TODO:не знаю как описать
        public HomeViewModel()
        {
            
            Tabs = new ObservableCollection<Tab>
            {
                new Tab() { Title = "Типы устройств", Icon =  '\uEE65' },
                
            };
            //Tabs.Add(new Tab() { Title = "Impostazioni",Icon = "" });
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


    /// <summary>
    /// Вкладка
    /// </summary>
    public class Tab
    {
        /// <summary>
        /// Заглавие
        /// </summary>
        public string Title
        {
            get; set;
        }
       
        /// <summary>
        /// Иконка
        /// </summary>
        public object Icon
        {
            get; set;
        }
        /// <summary>
        /// Страница
        /// </summary>
        public Page Page
        {
            get; set;
        }
    }
}
