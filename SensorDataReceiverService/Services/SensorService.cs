using SensorDataReceiverService.Models;
using SensorDataReceiverService.Repository.Interfaces;

namespace SensorDataReceiverService.Services.Interfaces
{
    public class SensorService : ISensor
    {
        public readonly ISensorRepository _repository;

        public SensorService(ISensorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Sensor> Add(Sensor sensor)
        {
            await _repository.Add(sensor);
            return sensor;
        }

        public async Task<Sensor?> Get(string id)
        {
            return await _repository.Get(id);
        }
    }
}