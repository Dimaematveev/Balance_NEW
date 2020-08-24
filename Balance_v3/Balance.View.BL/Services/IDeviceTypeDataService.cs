using Balance.Model.Dictionary;
using System.Collections.Generic;

namespace Balance.View.Dictionary.Services
{
    /// <summary>
    /// Интерфейс Службы данных [Типов устройств]
    /// </summary>
    public interface IDeviceTypeDataService
    {
        /// <summary>
        /// Удалить [Тип устройства] из хранилища
        /// </summary>
        /// <param name="deviceType">[Тип устройства] для удаления</param>
        void Delete(DeviceType deviceType);
        /// <summary>
        /// Обновить [Тип устройства] в хранилище
        /// </summary>
        /// <param name="deviceType">Обновленный [Тип устройства]</param>
        void Update(DeviceType deviceType);


        /// <summary>
        /// Получить все [Типы устройств]
        /// </summary>
        /// <returns>Список [Типов устройства]</returns>
        List<DeviceType> GetAll();
        /// <summary>
        /// Получить подробную информацию об [Типе устройства]
        /// </summary>
        /// <param name="deviceTypeID">Id [Типа устройства]</param>
        /// <returns>Машина</returns>
        DeviceType GetDetail(int deviceTypeID);

    }
}
