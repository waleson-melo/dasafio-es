using SensorDataReceiverService.Data;
using SensorDataReceiverService.Models;
using SensorDataReceiverService.Repository.Interfaces;

namespace SensorDataReceiverService.Repository
{
    public class SensorRepository : ISensorRepository
    {
        public readonly CosmosContext _dbContext;

        public SensorRepository(CosmosContext sensorDataReceiverContext)
        {
            _dbContext = sensorDataReceiverContext;
        }

        public async Task<Sensor> Add(Sensor sensor)
        {
            _dbContext.Add(sensor);
            await _dbContext.SaveChangesAsync();
            return sensor;
        }

        public async Task<Sensor?> Get(string id)
        {       
            if (_dbContext.sensor != null)
            {
                return await _dbContext.sensor.FindAsync(id);
            }
            
            return null;
        }
    }
}