using SensorDataReceiverService.Models.DTOs;

namespace SensorDataReceiverService.Services.Interfaces
{
    public interface IMessageSensorPublisher
    {
        Task Publish(SensorMessagePublishDTO sensorDTO);
        // Task Publish(string raw);
    }
}