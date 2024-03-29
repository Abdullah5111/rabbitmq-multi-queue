using MassTransit;
using Service3.Consumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration of MassTransit with RabbitMQ
builder.Services.AddMassTransit(config => {
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(new Uri("rabbitmq://localhost"), h => {
            h.Username("guest");
            h.Password("guest");
        });

        // Configuration of the consumers which will be executed automatically when message is received in queue
        // The queue name is identified as per MassTransit queue naming convention

        cfg.ReceiveEndpoint("SharedContent.Message:Tokenn2", ep => {
            ep.Consumer<Service1Consumer>();
        });

        cfg.ReceiveEndpoint("SharedContent.Message:Notification", ep => {
            ep.Consumer<Service2Consumer>();
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
