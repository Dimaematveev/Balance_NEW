using Meccanici.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace Meccanici.ViewModel
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
                OnPropertyChanged("Tabs");
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
                OnPropertyChanged("SelectedTab");
                LoadFrame();
            }
        }
        //TODO:не уверен
        /// <summary>
        /// Страница выбранной вкладки
        /// </summary>
        private Page tabPage;
        //TODO:не уверен
        /// <summary>
        /// Страница выбранной вкладки
        /// </summary>
        public Page TabPage
        {
            get { return tabPage; }
            set
            {
                tabPage = value;
                OnPropertyChanged("TabPage");
            }
        }

        /// <summary>
        /// Загрузить Страницу по Вкладке
        /// </summary>
        void LoadFrame()
        {
            switch (SelectedTab.Title)
            {
                case "Clienti":
                    TabPage = new ClientiView();
                    break;
                case "Automobili":
                    TabPage = new AutoView();
                    break;
                case "Riparazioni":
                    TabPage = new FixesView();
                    break;
                case "Dipendenti":
                    TabPage = new ClientiView(true);
                    break;
                case "Impostazioni":
                    TabPage = new SettingsView();
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
                new Tab() { Title = "Clienti", Icon = "" },
                new Tab() { Title = "Automobili", Icon = "" },
                new Tab() { Title = "Riparazioni", Icon = "" },
                new Tab() { Title = "Dipendenti", Icon = "" }
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
        /// Изображение
        /// </summary>
        public string Image
        {
            get
            {
                return "/Assets/" + Title + ".png";
            }
        }
        /// <summary>
        /// Иконка
        /// </summary>
        public string Icon
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
