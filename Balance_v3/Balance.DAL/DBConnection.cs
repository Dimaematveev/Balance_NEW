using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

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
        private SqlConnection connection;

        public DBConnection()
        {
            Connect();
            instance = this;
        }

        /// <summary>
        /// Открыть соединение с БД
        /// </summary>
        public void Connect()
        {

            if (connection == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionWork"].ConnectionString;
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
            Connect();
            SqlCommand command = new SqlCommand(nameProcedure, connection);
            // указываем, что команда представляет хранимую процедуру
            command.CommandType = System.Data.CommandType.StoredProcedure;
            if (sqlParameters != null && sqlParameters.Count > 0) 
            {
                command.Parameters.AddRange(sqlParameters.ToArray());
            }
            var res = command.ExecuteReader();
           
            return res;
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
