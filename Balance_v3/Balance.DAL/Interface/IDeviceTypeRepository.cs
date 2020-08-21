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
        void Delete(DeviceType deviceType);
        /// <summary>
        /// Обновить [Тип устройства] в хранилище
        /// </summary>
        /// <param name="deviceType">Обновленный [Тип устройства]</param>
        void Update(DeviceType deviceType);
        /// <summary>
        /// Добавить новый [Тип устройства] в хранилище
        /// </summary>
        /// <param name="deviceType">Новый [Тип устройства]</param>
        void New(DeviceType deviceType);


        /// <summary>
        /// Получить все [Типы устройств]
        /// </summary>
        /// <returns>Список [Типов устройства]</returns>
        List<DeviceType> GetAll();
        /// <summary>
        /// Получить подробную информацию об [Типе устройства]
        /// </summary>
        /// <param name="deviceTypeID">Id [Типа устройства]</param>
        /// <returns>[Типа устройства]</returns>
        DeviceType GetDetail(int deviceTypeID);
    }
}
