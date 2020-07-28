using System.Data.SqlClient;

namespace Connected
{
    public class Connect
    {
        /// <summary> Строка соединения с БД </summary>
        public const string _connetionString = @"Data Source=LAPTOP-ASUS; Initial Catalog = BalanceTest; Integrated Security = True; User Id = sa; Password = qwerty";
        /// <summary> Создание подключения </summary>
        public SqlConnection connection = new SqlConnection(_connetionString);

        /// <summary> Строка Выводящая получилось ли подключение </summary>
        public string _resultConnection;

        public Connect()
        {
            _resultConnection = ConnectString();
        }

        /// <summary>
        /// Открывает соединение и вывод результата.
        /// </summary>
        /// <returns> Возвращает строку показывающую установилось соединение</returns>
        public string ConnectString()
        {
            string res;

            try
            {
                connection.Open();
                res = "Подключение установлено";
                return res;
            }
            catch (SqlException ex)
            {
                res = ex.Message;
                return res;
            }
        }


        /// <summary>
        /// Закрывает соединение 
        /// </summary>
        public void ConnectClose()
        {
            connection.Close();
        }


        /// <summary>
        ///  На строку sql выводит dataset
        /// </summary>
        /// <param name="_SqlString"> Запрос sql</param>
        /// <returns> Выводит DataSet из запроса</returns>
        public SqlDataAdapter ExecuteCommand(string _SqlString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(_SqlString, connection);
            return adapter;
        }
    }
}
