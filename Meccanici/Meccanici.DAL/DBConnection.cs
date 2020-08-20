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
        public SqlConnection connection;

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
        /// Выполнить запрос
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Вывод данных</returns>
        public DbDataReader ExecuteQuery(string query)
        {
            Connect();
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// Вставить данные
        /// </summary>
        /// <param name="table">Таблица для вставки</param>
        /// <param name="names"> Имена столбцов через запятую </param>
        /// <param name="values"> Значения через запятую</param>
        public void InsertInto(string table, string names, string values)
        {
            string query = string.Format("insert into {0}.{1}({2}) values ({3})", connection.Database, table, names, values);
            ExecuteQuery(query);
        }
        /// <summary>
        /// Удалить данные
        /// </summary>
        /// <param name="table">Таблица для удаления</param>
        /// <param name="id"> Как можно индефицировать id удаляемого элемента</param>
        public void Delete(string table, string id)
        {
            string query = string.Format("update {0}.{1} set IsDelete=1 where {2}", connection.Database, table, id);
            ExecuteQuery(query);
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
