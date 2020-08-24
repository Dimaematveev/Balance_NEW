using Balance.Model;
using System.Collections.Generic;

namespace Balance.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище Общее
    /// </summary>
    public interface IDeviceCommonRepository<T> where T : CommonModel
    {
        string ErrorText { get; }
        /// <summary>
        /// Удалить [Что-то] из хранилища
        /// </summary>
        /// <param name="commonModel">[Что-то] для удаления</param>
        /// <returns>Без ошибок - true, С ошибкой - false</returns>
        bool Delete(T commonModel);
        /// <summary>
        /// Обновить [Что-то] в хранилище
        /// </summary>
        /// <param name="commonModel">Обновленный [Что-то]</param>
        /// <returns>Без ошибок - true, С ошибкой - false</returns>
        bool Update(T commonModel);
        /// <summary>
        /// Добавить новый [Что-то] в хранилище
        /// </summary>
        /// <param name="commonModel">Новый [Что-то]</param>
        /// <returns>Без ошибок - true, С ошибкой - false</returns>
        bool AddNew(T commonModel);


        /// <summary>
        /// Получить все [Что-то]
        /// </summary>
        /// <returns>Список [Что-то]</returns>
        List<T> GetAll();
        /// <summary>
        /// Получить подробную информацию об [Что-то]
        /// </summary>
        /// <param name="commonModelID">Id [Что-то]</param>
        /// <returns>[Что-то]</returns>
        T GetDetail(int commonModelID);
    }
}
