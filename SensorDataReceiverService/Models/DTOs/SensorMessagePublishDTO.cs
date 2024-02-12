namespace SensorDataReceiverService.Models.DTOs
{
    public class SensorMessagePublishDTO
    {
        public string? SensorId { get; set; }
        public float Temperature { get; set; }
    }
}