﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Connected
{
    public class Connect
    {
        /// <summary> Строка соединения с БД </summary>
        public readonly string _connetionString = @"Data Source=LAPTOP-ASUS; Initial Catalog = BalanceTest; Integrated Security = True; User Id = sa; Password = qwerty";
        /// <summary> Создание подключения </summary>
        public SqlConnection connection;

        /// <summary> Строка Выводящая получилось ли подключение </summary>
        public string _resultConnection;

        public Connect()
        {
            connection = new SqlConnection(_connetionString); 
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

        public string ExecAction(string _SqlExecProcedure)
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

        public string ExecuteProcedure(string _SqlExecProcedure, SqlParameter[] sqlParameters)
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
        public DataTable GetData(string _SqlString)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(_SqlString, connection);
            sqlDataAdapter.Fill(dataSet);
            var table = dataSet.Tables[0];
            return table;

        }



    }
}