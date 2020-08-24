using Balance.DAL.Interface;
using Balance.Model;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Balance.DAL.InterfaceRealization
{
    public abstract class DeviceCommonRepository<T> : IDeviceCommonRepository<T> where T : CommonModel
    {
        public string ErrorText { get; private set; }
        /// <summary>
        /// Список [Чего-то]
        /// </summary>
        protected List<T> commonModels;
        /// <summary>
        /// Имя Схемы 
        /// </summary>
        protected abstract string SHEMA_NAME { get; }
        /// <summary>
        /// Имя таблицы с данными
        /// </summary>
        protected abstract string TABLE_NAME { get; }

        public bool Delete(T commonModel)
        {
            ErrorText = null;
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TypeProcedure", "Delete"),
                new SqlParameter("@ID", commonModel.ID)
            };
            var newcommonModel = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[WorkingWith_{TABLE_NAME}]", sqlParameters);
            if (DBConnection.instance.ThereIsError)
            {
                ErrorText = DBConnection.instance.ErrorText;
                return false;
            }
            newcommonModel.Read();
            commonModels.Remove(commonModel);
            newcommonModel.Close();
            return true;
        }

        public bool AddNew(T commonModel)
        {
            ErrorText = null;
            if (commonModel != null && commonModels != null)
            {
                var sqlParameters = GetSqlParameters(commonModel);
                sqlParameters.Add(new SqlParameter("@TypeProcedure", "Insert"));
                var newcommonModel = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[WorkingWith_{TABLE_NAME}]", sqlParameters);
                if (DBConnection.instance.ThereIsError)
                {
                    ErrorText = DBConnection.instance.ErrorText;
                    return false;
                }
                newcommonModel.Read();
                commonModel.AllFill(GetDeviceTypeFromDataReader(newcommonModel));
                commonModels.Add(commonModel);
                newcommonModel.Close();

            }
            return true;
        }

        public bool Update(T commonModel)
        {
            ErrorText = null;
            T commonModelToUpdate = commonModels.Where(x => x.ID == commonModel.ID).FirstOrDefault();
            var sqlParameters = GetSqlParameters(commonModel);
            sqlParameters.Add(new SqlParameter("@TypeProcedure", "Update"));
            sqlParameters.Add(new SqlParameter("@ID", commonModel.ID));
            var newcommonModel = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[WorkingWith_{TABLE_NAME}]", sqlParameters);
            if (DBConnection.instance.ThereIsError)
            {
                ErrorText = DBConnection.instance.ErrorText;
                return false;
            }
            newcommonModel.Read();
            commonModel.Fill(GetDeviceTypeFromDataReader(newcommonModel));
            commonModelToUpdate.Fill(commonModel);
            newcommonModel.Close();
            return true;
        }

        public List<T> GetAll()
        {
            if (commonModels == null)
                LoadCommonModels();
            return commonModels.ToList();
        }

        public T GetDetail(int commonModelID)
        {
            if (commonModels == null)
                LoadCommonModels();
            return commonModels.Where(x => x.ID == commonModelID).FirstOrDefault();
        }

        /// <summary>
        /// Загрузить [что-то] из таблицы
        /// </summary>
        private void LoadCommonModels()
        {
            commonModels = new List<T>();
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@TypeProcedure", "Select")
            };
            var allCommonModels = DBConnection.instance.ExecuteProcedure($"[{SHEMA_NAME}].[WorkingWith_{TABLE_NAME}]", sqlParameters);
            while (allCommonModels.Read())
            {
                commonModels.Add(GetDeviceTypeFromDataReader(allCommonModels));
            }
            allCommonModels.Close();
        }

        /// <summary>
        /// Получить Sql парамеры для процедур. Кроме ID и IsDelete
        /// </summary>
        /// <param name="commonModel">По чему делать Параметры</param>
        /// <returns>Список sql параметров</returns>
        internal abstract List<SqlParameter> GetSqlParameters(T commonModel);

        /// <summary>
        /// Получить [Что-то] из таблицы
        /// </summary>
        /// <param name="dbDataReader"></param>
        /// <returns></returns>
        internal abstract T GetDeviceTypeFromDataReader(DbDataReader dbDataReader);
    }
}
