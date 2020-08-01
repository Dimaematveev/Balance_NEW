using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace EditAddDevice
{
    /// <summary>
    /// Interaction logic for AddPrinter.xaml
    /// </summary>
    public partial class AddPrinterWPF : UserControl, ISingleDevice
    {
        /// <summary>
        /// Проверка что все обязательные поля заполнены
        /// </summary>
        public List<string> Verification()
        {
            List<string> res = new List<string>();

            if (string.IsNullOrEmpty(AddPagesPerMinute.Text) || !int.TryParse(AddPagesPerMinute.Text, out int pagesPerMinute) || pagesPerMinute <= 0) 
            {
                Grid parent = (Grid)AddPagesPerMinute.Parent;
                res.Add($"Поле [{((Label)parent.Children[0]).Content}] должно быть обязательно заполнено! И это должно быть число > 0.Сейчас:{AddPagesPerMinute.Text}.");
            }


            
            return res; 
        }

        public AddPrinterWPF()
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
