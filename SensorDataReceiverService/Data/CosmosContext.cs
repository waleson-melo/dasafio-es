using Microsoft.EntityFrameworkCore;
using SensorDataReceiverService.Models;

namespace SensorDataReceiverService.Data
{
    public class CosmosContext : DbContext
    {
        public DbSet<Sensor>? sensor { get; set; }

        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>()
                .ToContainer("Sensors")
                .HasPartitionKey(e => e.SensorId);
        }
    }
}