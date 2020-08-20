using Meccanici.Model;
using System.Collections.Generic;

namespace Meccanici.Services
{
    /// <summary>
    /// Интерфейс Службы данных автомобиля
    /// </summary>
    public interface ICarDataService
    {
        //TODO:customer заменить  на автомобиль
        /// <summary>
        /// Удалить автомобиль
        /// </summary>
        /// <param name="customer">Удаляемый автомобиль </param>
        void DeleteCar(Auto customer);
        //TODO:customer заменить  на автомобиль
        /// <summary>
        /// Обновить машину в хранилище
        /// </summary>
        /// <param name="customer">Обновленная машина</param>
        void UpdateCar(Auto customer);


        /// <summary>
        /// Получить список всех автомобилей
        /// </summary>
        /// <returns>Список автомобилей</returns>
        List<Auto> GetAllCars();
        //TODO:customerID заменить  на автомобиль
        /// <summary>
        /// Получить подробную информацию об автомобиле
        /// </summary>
        /// <param name="customerID">Id машины</param>
        /// <returns>Машина</returns>
        Auto GetCarDetail(int customerID);

        
    }
}
