using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.Services
{
    /// <summary>
    /// Интерфейс Службы данных Клиента
    /// </summary>
    public interface IMechanicDataService
    {
        //TODO: заменить customer на mechanic
        /// <summary>
        /// Удалить механика
        /// </summary>
        /// <param name="customer">Человек для удаления</param>
        void DeleteMechanic(Person customer);
        //TODO: заменить customer на mechanic
        /// <summary>
        /// Обновить механика
        /// </summary>
        /// <param name="customer">Человек для обновления</param>
        void UpdateMechanic(Person customer);

        /// <summary>
        /// Поучить список всех механиков
        /// </summary>
        /// <returns>Список Людей</returns>
        List<Person> GetAllMechanics();
        //TODO: заменить customerid на mechanic
        /// <summary>
        /// Получить сведения о механике
        /// </summary>
        /// <param name="customerID">ID механика</param>
        /// <returns>Человек</returns>
        Person GetMechanicDetail(int customerID);
       
    }
}
