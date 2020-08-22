using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Balance.DAL
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
        private readonly SqlConnection connection;

        public DBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionWork"].ConnectionString;
            connection = new SqlConnection(connectionString);
            Open();
            instance = this;
        }

        


        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Вывод данных</returns>
        public DbDataReader ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            var res = command.ExecuteReader();
            
            return res;
        }
        /// <summary>
        /// Выполнить процедуру
        /// </summary>
        /// <param name="nameProcedure">Название процедуры</param>
        /// <param name="sqlParameters">Параметры</param>
        /// <returns>Вывод результата</returns>
        public DbDataReader ExecuteProcedure(string nameProcedure, List<SqlParameter> sqlParameters = null)
        {
            SqlCommand command = new SqlCommand(nameProcedure, connection)
            {
                // указываем, что команда представляет хранимую процедуру
                CommandType = System.Data.CommandType.StoredProcedure
            };
            if (sqlParameters != null && sqlParameters.Count > 0) 
            {
                command.Parameters.AddRange(sqlParameters.ToArray());
            }
            var res = command.ExecuteReader();
           
            return res;
        }

        /// <summary>
        /// Открыть соединение
        /// </summary>
        public void Open()
        {
            connection.Open();
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
