using Balance.Model.Devices;

namespace Balance.DAL.Interface.Devices
{
    /// <summary>
    /// Интерфейс хранилище [Общих устройств]
    /// </summary>
    public interface IGeneralDeviceRepository<T> : IDeviceCommonRepository<T> where T: GeneralDevice
    {
    }
}
