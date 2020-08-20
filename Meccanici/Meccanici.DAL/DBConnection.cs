using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Meccanici.DAL
{
    /// <summary>
    /// Соединение с БД
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// экземпляр объекта Соединения с БД
        /// </summary>
        public static DBConnection instance;
        /// <summary>
        /// Подключение к БД
        /// </summary>
        private SqlConnection connection;

        public DBConnection()
        {
            
            instance = this;
        }

        /// <summary>
        /// Открыть соединение с БД
        /// </summary>
        public void Connect()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
            }
            else
            {
                connection.Close();
            }
            connection.Open();
        }
        /// <summary>
        /// Выполнить запрос Асинхронно
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Вывод данных</returns>
        public async Task<DbDataReader> ExecuteQuery(string query)
        {
            Connect();
            SqlCommand command = new SqlCommand(query, connection);
            return await command.ExecuteReaderAsync();
        }

        /// <summary>
        /// Вставить данные асинхронно
        /// </summary>
        /// <param name="table">Таблица для вставки</param>
        /// <param name="names"> Имена столбцов через запятую </param>
        /// <param name="values"> Значения через запятую</param>
        public async void InsertInto(string table, string names, string values)
        {
            string query = string.Format("insert into {0}.{1}({2}) values ({3})", connection.Database, table, names, values);
            await ExecuteQuery(query);
        }
        /// <summary>
        /// Закрыть соединение
        /// </summary>
        public void Close()
        {
            connection.Close();
        }
    }
}
