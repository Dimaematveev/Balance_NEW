using Balance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище [Типов устройств]
    /// </summary>
    public interface IDeviceTypeRepository
    {
        /// <summary>
        /// Удалить [Тип устройства] из хранилища
        /// </summary>
        /// <param name="deviceType">[Тип устройства] для удаления</param>
        void DeleteCar(DeviceType deviceType);
        /// <summary>
        /// Обновить [Тип устройства] в хранилище
        /// </summary>
        /// <param name="deviceType">Обновленный [Тип устройства]</param>
        void UpdateCar(DeviceType deviceType);
        /// <summary>
        /// Добавить новый [Тип устройства] в хранилище
        /// </summary>
        /// <param name="deviceType">Новый [Тип устройства]</param>
        void NewCar(DeviceType deviceType);


        /// <summary>
        /// Получить все [Типы устройств]
        /// </summary>
        /// <returns>Список [Типов устройства]</returns>
        List<DeviceType> GetAllCars();
        /// <summary>
        /// Получить подробную информацию об [Типе устройства]
        /// </summary>
        /// <param name="deviceTypeID">Id [Типа устройства]</param>
        /// <returns>Машина</returns>
        DeviceType GetCarDetail(string deviceTypeID);
    }
}
