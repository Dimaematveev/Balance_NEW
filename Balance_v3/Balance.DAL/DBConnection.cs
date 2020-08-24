using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Balance.DAL
{
    /// <summary>
    /// Соединение с БД
    /// </summary>
    public class DBConnection
    {
        /// <summary>
        /// Имеются ошибки запроса
        /// </summary>
        public bool ThereIsError;
        /// <summary>
        /// Текст ошибки
        /// </summary>
        public string ErrorText;

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
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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
            var res = ExecuteReader(command);
            if (ThereIsError)
            {
                return null;
            }
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
            var res = ExecuteReader(command);
            if (ThereIsError)
            {
                return null;
            }
            return res;
        }

        private DbDataReader ExecuteReader(SqlCommand command)
        {
            ThereIsError = false;
            ErrorText = null;
            DbDataReader res = null;

            try
            {
                res = command.ExecuteReader();
            }
            catch (SqlException sqlException)
            {
                ThereIsError = true;
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < sqlException.Errors.Count; i++)
                {
                    errorMessages.Append(
                        "Индекс #" + i + "\n" +
                        "Сообщение: " + sqlException.Errors[i].Message + "\n" +
                        "Номер строки: " + sqlException.Errors[i].LineNumber + "\n" +
                        "Процедура: " + sqlException.Errors[i].Procedure + "\n" + "\n"
                    );
                }
                ErrorText = errorMessages.ToString();
            }
            catch (Exception ex)
            {
                ThereIsError = true;
                ErrorText = ex.Message;
            }
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
