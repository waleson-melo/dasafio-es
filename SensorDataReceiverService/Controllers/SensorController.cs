using Microsoft.AspNetCore.Mvc;
using SensorDataReceiverService.Models;
using SensorDataReceiverService.Models.DTOs;
using SensorDataReceiverService.Services.Interfaces;

namespace SensorDataReceiverService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        public readonly ISensor _sensor;
        private readonly IMessageSensorPublisher _messageSensorPublisher;

        public SensorController(ISensor sensor, IMessageSensorPublisher messageSensorPublisher)
        {
            _sensor = sensor;
            _messageSensorPublisher = messageSensorPublisher;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> CreateSensor([FromBody] SensorCreateDTO sensorDTO){
            Sensor sensor = new()
            {
                SensorId = sensorDTO.SensorId,
                Temperature = sensorDTO.Temperature
            };

            var addedSensor = await _sensor.Add(sensor);

            SensorMessagePublishDTO sensorMessagePublishDTO = new()
            {
                SensorId = addedSensor.SensorId,
                Temperature = addedSensor.Temperature
            };
            await _messageSensorPublisher.Publish(sensorMessagePublishDTO);

            return CreatedAtAction(nameof(GetSensor), new { id = addedSensor.SensorId }, sensor);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetSensor(string id)
        {
            var sensor = await _sensor.Get(id);
            return sensor == null ? NotFound() : Ok(sensor);
        }
    }
}