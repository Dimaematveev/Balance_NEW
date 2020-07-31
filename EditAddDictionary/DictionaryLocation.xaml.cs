﻿using Connected;
using System;
using System.Data;
using System.Windows;

namespace EditAddDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DictionaryLocation : Window
    {
        /// <summary> подключение к sql. Сюда отправляются запросы и получаются ответы.  </summary>
        private DataRow DR { get; }

        public DictionaryLocation(DataRow dr)
        {
            InitializeComponent();
            DR = dr;
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;
            Loaded += DictionaryType_Loaded;
        }

        private void DictionaryType_Loaded(object sender, RoutedEventArgs e)
        {
            LocationName.Text = DR["Name"].ToString();
            if (DR["ID"] != DBNull.Value)
            {
                Add.Content = "Изменить";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string exeption;
            if (DR["ID"] == DBNull.Value)
            {
                exeption=Connect.ExecAction($"INSERT INTO [dic].[Location] ([Name]) VALUES (N'{LocationName.Text}')");
            }
            else
            {
                exeption=Connect.ExecAction($"Update [dic].[Location] set [Name] = N'{LocationName.Text}' where ID = {DR["ID"]}");
            }
            if (exeption!=null)
            {
                MessageBox.Show(exeption, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
            Close();
        }


    }
}
