using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище Клиентов
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Удалить клиента из хранилища
        /// </summary>
        /// <param name="customer">Человек для удаления</param>
        void DeleteCustomer(Person customer);
        /// <summary>
        /// Обновить клиента в хранилище
        /// </summary>
        /// <param name="customer">Человек для обновления</param>
        void UpdateCustomer(Person customer);
        /// <summary>
        /// Добавить нового клиента в хранилище
        /// </summary>
        /// <param name="customer">Новый Человек</param>
        void NewCustomer(Person customer);


        /// <summary>
        /// Поучить список всех клиентов
        /// </summary>
        /// <returns>Список Людей</returns>
        List<Person> GetAllCustomers();
        /// <summary>
        /// Получить сведения о клиенте
        /// </summary>
        /// <param name="customerID">ID клиента</param>
        /// <returns>Человек</returns>
        Person GetCustomerDetail(int customerID);
       
    }
}
