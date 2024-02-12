using SensorDataReceiverService.Models;

namespace SensorDataReceiverService.Repository.Interfaces
{
    public interface ISensorRepository
    {
        Task<Sensor> Add(Sensor sensor);
        Task<Sensor?> Get(string id);
    }
}