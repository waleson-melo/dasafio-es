using System.Text;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using SensorDataReceiverService.Models.DTOs;
using SensorDataReceiverService.Services.Interfaces;

namespace SensorDataReceiverService.Services
{
    public class MessageSensorPublish : IMessageSensorPublisher
    {
        private readonly IQueueClient _queueClient;

        public MessageSensorPublish(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public Task Publish(SensorMessagePublishDTO sensorDTO)
        {
            var objAsText = JsonConvert.SerializeObject(sensorDTO);
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            return _queueClient.SendAsync(message);
        }

        // public Task Publish(string raw)
        // {
        //     var message = new Message(Encoding.UTF8.GetBytes(raw));
        //     return _queueClient.SendAsync(message);
        // }
    }
}