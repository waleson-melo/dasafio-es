using Microsoft.Azure.ServiceBus;
using SensorDataProcessingService.Models;
using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SensorDataProcessingService
{
    internal class Program
    {
        const string connectionString = "";
        const string queueName = "";
        static IQueueClient queueClient;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Aguardando Mensagens");
            queueClient = new QueueClient(connectionString, queueName);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

            Console.ReadLine();

            await queueClient.CloseAsync();
        }

        private static async Task ProcessMessageAsync(Message message, CancellationToken token)
        {
            var jsonString = Encoding.UTF8.GetString(message.Body);
            Sensor sensor = JsonSerializer.Deserialize<Sensor>(jsonString);

            Console.WriteLine($"Dados recebidos: { sensor.SensorId } { sensor.Temperature }");

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler exception: { arg.Exception }");

            return Task.CompletedTask;
        }
    }
}
