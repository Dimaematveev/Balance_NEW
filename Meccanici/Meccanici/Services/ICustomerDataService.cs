using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.Services
{
    /// <summary>
    /// Интерфейс Службы данных Клиента
    /// </summary>
    public interface ICustomerDataService
    {
        /// <summary>
        /// Удалить клиента 
        /// </summary>
        /// <param name="customer">Человек для удаления</param>
        void DeleteCustomer(Person customer);
        /// <summary>
        /// Обновить клиента 
        /// </summary>
        /// <param name="customer">Человек для обновления</param>
        void UpdateCustomer(Person customer);

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
