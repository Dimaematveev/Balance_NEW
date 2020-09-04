﻿using Balance.BL.Interfaces;
using Balance.View.Dictionary.Views;
using Balance.ViewModel.Interface;
using Balance.ViewModel.InterfaceRealization;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace Balance.View.Main.ViewModels
{
    /// <summary>
    /// View-Model Домашней страницы
    /// </summary>
    public class HomeDictionaryViewModel : INotifyPropertyChanged
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
        /// Вывод сообщений
        /// </summary>
        private readonly MyMessage messageShow;

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
                if (TabPage?.DataContext is ICommonViewModel commonViewModel)
                {
                    if (commonViewModel.IsEditing)
                    {
                        messageShow.ShowMessage("Вы переходите на другую вкладку. Все изменения будут потеряны. Продолжить?", "Переход", TypeMessage.Question);
                        if (!messageShow.Result)
                        {
                            OnPropertyChanged(nameof(SelectedTab));
                            return;
                        }
                    }

                }
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
        public HomeDictionaryViewModel()
        {
            messageShow = new MessageShow();
            Tabs = new ObservableCollection<Tab>
            {
                new Tab() { Title = "Названия таблиц", Icon = '\uE155', OpenNewPage=new Func<Page>( () => {return new DeviceGadgetView(ViewModelLocator.DeviceGadgetViewModel); }) },
                new Tab() { Title = "Типы устройств", Icon = '\uE8CC', OpenNewPage=new Func<Page>( () => {return new DeviceTypeView(ViewModelLocator.DeviceTypeViewModel); }) },
                new Tab() { Title = "Модели устройств", Icon = '\uEDA4', OpenNewPage=new Func<Page>( () => {return new DeviceModelView(ViewModelLocator.DeviceModelViewModel); }) },
                new Tab() { Title = "Местоположение", Icon = '\uE726', OpenNewPage=new Func<Page>( () => {return new LocationView(ViewModelLocator.LocationViewModel); }) },
                new Tab() { Title = "СП и СИ", Icon = '\uE1DE', OpenNewPage=new Func<Page>( () => {return new SPSIView(ViewModelLocator.SPSIViewModel); }) },
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



}
