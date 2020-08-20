using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище Механиков
    /// </summary>
    public interface IMechanicRepository
    {
        /// <summary>
        /// Удалить механика из хранилища
        /// </summary>
        /// <param name="mechanic">Человек для удаления</param>
        void DeleteMechanic(Person mechanic);

        /// <summary>
        /// Обновить механика в хранилище
        /// </summary>
        /// <param name="mechanic">Человек для обновления</param>
        void UpdateMechanic(Person mechanic);
        //TODO: изменить selectedCustomer на selectedMechanic
        /// <summary>
        /// Добавить нового механика в хранилище
        /// </summary>
        /// <param name="selectedCustomer">Новый Человек</param>
        void NewEmployee(Person selectedCustomer);


        /// <summary>
        /// Поучить список всех механиков
        /// </summary>
        /// <returns>Список Людей</returns>
        List<Person> GetAllMechanics();
        /// <summary>
        /// Получить сведения о механике
        /// </summary>
        /// <param name="mechanicID">ID механика</param>
        /// <returns>Человек</returns>
        Person GetMechanicDetail(int mechanicID);
     
    }
}
