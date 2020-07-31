using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Connected
{
    public static class Connect
    {
        /// <summary> Строка соединения с БД </summary>
        public static readonly string _connetionString;
        /// <summary> Создание подключения </summary>
        public static SqlConnection connection;
        //Показывает подключились или нет
        public static bool _IsOpen;
        /// <summary> Строка Выводящая получилось ли подключение </summary>
        public static string _resultConnection;

        static Connect()
        {
            
            _connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(_connetionString); 
            _resultConnection = ConnectString();
        }

        /// <summary>
        /// Открывает соединение и вывод результата.
        /// </summary>
        /// <returns> Возвращает строку показывающую установилось соединение</returns>
        public static string ConnectString()
        {
            string res;

            try
            {
                _IsOpen = true;
                connection.Open();
                res = "Подключение установлено";
                return res;
            }
            catch (SqlException ex)
            {
                _IsOpen = false;
                res = ex.Message;
                return res;
            }
        }


        /// <summary>
        /// Закрывает соединение 
        /// </summary>
        public static void ConnectClose()
        {
            connection.Close();
        }


        ///// <summary>
        /////  На строку sql выводит dataset
        ///// </summary>
        ///// <param name="_SqlString"> Запрос sql</param>
        ///// <returns> Выводит DataSet из запроса</returns>
        //private SqlDataAdapter ExecuteCommand(string _SqlString)
        //{

        //    SqlDataAdapter adapter = new SqlDataAdapter(_SqlString, connection);
        //    return adapter;
        //}

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
