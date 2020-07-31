using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Connected
{
    public static class Connect
    {
        /// <summary> Строка соединения с БД </summary>
        private static string _connetionString;
        /// <summary>
        /// название используемого соединения
        /// </summary>
        public static string NameConnectionString;
        /// <summary> Создание подключения </summary>
        public static SqlConnection connection;
        //Показывает подключились или нет
        public static bool _IsOpen;
        /// <summary> Строка Выводящая получилось ли подключение </summary>
        public static string _resultConnection;

        static Connect()
        {
            NameConnectionString = "DefaultConnection";
            
            
        }

        /// <summary>
        /// Открывает соединение и вывод результата.
        /// </summary>
        /// <returns> Возвращает строку показывающую установилось соединение</returns>
        public static string ConnectOpen()
        {
            string res;

            try
            {
                _connetionString = ConfigurationManager.ConnectionStrings[NameConnectionString].ConnectionString;
                connection = new SqlConnection(_connetionString);
                connection.Open();
                _IsOpen = true;
                res = "Подключение установлено \n";
                res += $"Database:{connection.Database} \n";
                _resultConnection = res;
            }
            catch (SqlException ex)
            {
                _IsOpen = false;
                res = ex.Message;
                _resultConnection = res;

            }
            _resultConnection = res;
            return _resultConnection;
        }


        /// <summary>
        /// Закрывает соединение 
        /// </summary>
        public static void ConnectClose()
        {
            connection.Close();
        }


        public static string ExecAction(string _SqlExecProcedure)
        {

            SqlCommand command = new SqlCommand(_SqlExecProcedure, connection)
            {
                // указываем, что команда представляет хранимую процедуру
                CommandType = System.Data.CommandType.Text
            };


            try
            {
                command.ExecuteNonQuery();
                return null;
            }
            catch (SqlException sqlEx)
            {
                return sqlEx.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string ExecuteProcedure(string _SqlExecProcedure, SqlParameter[] sqlParameters)
        {

            SqlCommand command = new SqlCommand(_SqlExecProcedure, connection)
            {
                // указываем, что команда представляет хранимую процедуру
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddRange(sqlParameters);
            

            try
            {
                command.ExecuteNonQuery();
                return null;
            }
            catch (SqlException sqlEx)
            {
                
                return sqlEx.Message;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        /// <summary>
        ///  На строку sql выводит данные в виде таблицы
        /// </summary>
        /// <param name="_SqlString"> Запрос sql</param>
        /// <returns> Выводит DataSet из запроса</returns>
        public static DataTable GetData(string _SqlString)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_SqlString, connection);
            sqlDataAdapter.Fill(dataSet);
            var table = dataSet.Tables[0];
            return table;

        }



    }
}
