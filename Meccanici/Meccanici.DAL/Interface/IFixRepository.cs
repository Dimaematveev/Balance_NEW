using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище ремонта/Заявок на ремонт
    /// Исправлений/Установок/Фиксирования
    /// </summary>
    public interface IFixRepository
    {
        /// <summary>
        /// Удалить Заявку из Хранилища
        /// </summary>
        /// <param name="fix">Удаляемая заявка</param>
        void DeleteFix(Riparazione fix);
        /// <summary>
        /// Обновить заявку в хранилище
        /// </summary>
        /// <param name="fix">Обновленная заявка</param>
        void UpdateFix(Riparazione fix);
        /// <summary>
        ///Добавить новую заявку в хранилище
        /// </summary>
        /// <param name="fix">Новая заявка</param>
        void NewFix(Riparazione fix);


        /// <summary>
        /// Получить все заявки
        /// </summary>
        /// <returns>Список заявок</returns>
        List<Riparazione> GetAllFixes();
        /// <summary>
        /// Получить Список заявок по машине
        /// </summary>
        /// <param name="targa">Номерной знак машины</param>
        /// <returns>Список заявок</returns>
        List<Riparazione> GetCarFixes(string targa);
        /// <summary>
        /// Получить Список заявок механика
        /// </summary>
        /// <param name="mechId">id механика</param>
        /// <returns></returns>
        List<Riparazione> GetMechanicFixes(int mechId);
        /// <summary>
        /// Получить сведения о заявке
        /// </summary>
        /// <param name="fixID">id заявки</param>
        /// <returns>Заявка</returns>
        Riparazione GetFixDetail(int fixID);
       

    }
}
