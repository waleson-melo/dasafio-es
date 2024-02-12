using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SensorDataReceiverService.Models
{
    public class Sensor
    {
        public string? SensorId { get; set; }
        public float Temperature { get; set; }
    }
}