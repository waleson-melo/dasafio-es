using SensorDataReceiverService.Models;

namespace SensorDataReceiverService.Services.Interfaces
{
    public interface ISensor
    {
        Task<Sensor> Add(Sensor sensor);
        Task<Sensor?> Get(string id);
    }
}