using Balance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balance.DAL.Interface
{
    /// <summary>
    /// Интерфейс хранилище [Моделей устройств]
    /// </summary>
    public interface IDeviceModelRepository
    {
        /// <summary>
        /// Удалить [Модель устройства] из хранилища
        /// </summary>
        /// <param name="deviceModel">[Модель устройства] для удаления</param>
        void Delete(DeviceModel deviceModel);
        /// <summary>
        /// Обновить [Модель устройства] в хранилище
        /// </summary>
        /// <param name="deviceModel">Обновленный [Модель устройства]</param>
        void Update(DeviceModel deviceModel);
        /// <summary>
        /// Добавить новый [Модель устройства] в хранилище
        /// </summary>
        /// <param name="deviceModel">Новый [Модель устройства]</param>
        void New(DeviceModel deviceModel);


        /// <summary>
        /// Получить все [Модели устройств]
        /// </summary>
        /// <returns>Список [Модели устройства]</returns>
        List<DeviceModel> GetAll();
        /// <summary>
        /// Получить подробную информацию об [Модели устройства]
        /// </summary>
        /// <param name="deviceModelID">Id [Модель устройства]</param>
        /// <returns>[Модель устройства]</returns>
        DeviceModel GetDetail(int deviceModelID);
    }
}
