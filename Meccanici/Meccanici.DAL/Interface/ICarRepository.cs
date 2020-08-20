using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище машин
    /// </summary>
    public interface ICarRepository
    {
        /// <summary>
        /// Удалить машину из хранилища
        /// </summary>
        /// <param name="car">Машина для удаления</param>
        void DeleteCar(Auto car);
        /// <summary>
        /// Обновить машину в хранилище
        /// </summary>
        /// <param name="car">Обновленная машина</param>
        void UpdateCar(Auto car);
        /// <summary>
        /// Добавить новую машину в хранилище
        /// </summary>
        /// <param name="car">Новая машина</param>
        void NewCar(Auto car);


        /// <summary>
        /// Получить все машины?
        /// </summary>
        /// <returns>Список машин</returns>
        List<Auto> GetAllCars();
        /// <summary>
        /// Получит все машины определенного Клиента
        /// </summary>
        /// <param name="custID">id клиента</param>
        /// <returns>Список машин</returns>
        List<Auto> GetCustomerCars(int custID);
        /// <summary>
        /// Получить подробную информацию об автомобиле
        /// </summary>
        /// <param name="carID">Id машины</param>
        /// <returns>Машина</returns>
        Auto GetCarDetail(string carID);
     
    }
}
