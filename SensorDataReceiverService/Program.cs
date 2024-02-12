using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using SensorDataReceiverService.Data;
using SensorDataReceiverService.Repository;
using SensorDataReceiverService.Repository.Interfaces;
using SensorDataReceiverService.Services;
using SensorDataReceiverService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// DbContext
builder.Services.AddDbContext<CosmosContext>(options => {
    options.UseCosmos(
        builder.Configuration.GetConnectionString("URL"),
        builder.Configuration.GetConnectionString("Key1"),
        builder.Configuration.GetConnectionString("DBName")
    );
});
// Services
builder.Services.AddTransient<ISensor, SensorService>();
builder.Services.AddSingleton<IQueueClient>(x => new QueueClient(
    builder.Configuration.GetConnectionString("PrimaryConnectionString"),
    builder.Configuration.GetConnectionString("QueueName")
));
builder.Services.AddSingleton<IMessageSensorPublisher, MessageSensorPublish>();

// Repository
builder.Services.AddScoped<ISensorRepository, SensorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
