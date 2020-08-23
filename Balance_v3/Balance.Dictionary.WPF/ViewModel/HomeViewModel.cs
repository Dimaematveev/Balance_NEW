using Balance.Dictionary.WPF.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace Balance.Dictionary.WPF.ViewModel
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
                TabPage = selectedTab.OpenNewPage();
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
        public HomeViewModel()
        {

            Tabs = new ObservableCollection<Tab>
            {
                new Tab() { Title = "Названия таблиц", Icon = '\uE155', OpenNewPage=new Func<Page>( () => {return new DeviceGadgetView(); }) },
                new Tab() { Title = "Типы устройств", Icon = '\uE8CC', OpenNewPage=new Func<Page>( () => {return new DeviceTypeView(); }) },
                new Tab() { Title = "Модели устройств", Icon = '\uEDA4', OpenNewPage=new Func<Page>( () => {return new DeviceModelView(); }) },
                new Tab() { Title = "Местоположение", Icon = '\uE726', OpenNewPage=new Func<Page>( () => {return new LocationView(); }) },
                new Tab() { Title = "СП и СИ", Icon = '\uE1DE', OpenNewPage=new Func<Page>( () => {return new SPSIView(); }) },
            };
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
        public char Icon
        {
            get; set;
        }
        /// <summary>
        /// Страница
        /// </summary>
        public Func<Page> OpenNewPage
        {
            get; set;
        }
    }
}
