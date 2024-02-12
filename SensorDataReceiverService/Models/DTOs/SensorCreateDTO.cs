namespace SensorDataReceiverService.Models.DTOs
{
    public class SensorCreateDTO
    {
        public string? SensorId { get; set; }
        public float Temperature { get; set; }
    }
}