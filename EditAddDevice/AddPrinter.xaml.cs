﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EditAddDevice
{
    /// <summary>
    /// Interaction logic for AddPrinter.xaml
    /// </summary>
    public partial class AddPrinter : UserControl, ISingleDevice
    {
        /// <summary>
        /// Проверка что все обязательные поля заполнены
        /// </summary>
        public List<string> Verification()
        {
            List<string> res = new List<string>();

            if (string.IsNullOrEmpty(AddPagesPerMinute.Text) || AddPagesPerMinute.Text.Length > 50) 
            {
                Grid parent = (Grid)AddPagesPerMinute.Parent;
                res.Add($"Поле [{((Label)parent.Children[0]).Content}] должно быть обязательно заполнено! И длина должна быть от 1 до 50 символов.Сейчас:{AddPagesPerMinute.Text.Length}.");
            }


            
            return res; 
        }

        public AddPrinter()
        {
            InitializeComponent();
        }

        
        
        public List<SqlParameter> GetSqlParameters()
        {
            if (Verification().Count == 0)
            {
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                //Обязательные параметры не могут быть null
                sqlParameters.Add(new SqlParameter("@PagesPerMinute", AddPagesPerMinute.Text));

                //необязательные параметры могут быть null


                return sqlParameters;
            }
            return null;
        }

        public UIElement GetUIElement()
        {
            return this;
        }

        public double GetHeight()
        {
            return Height;
        }
    }
}
