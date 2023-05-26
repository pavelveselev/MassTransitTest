using Common.Messages;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddMassTransit(x =>
    {
        var host = "localhost";

        x.UsingRabbitMq((context, cfg) =>
        {
            EndpointConvention.Map<TestMessage>(new Uri($"queue:test_queue"));

            cfg.Host(new Uri($"rabbitmq://{host}/"), h =>
            {
                h.RequestedConnectionTimeout(TimeSpan.FromHours(12));
                //h.Username(userName);
                //h.Password(password);
            });
        });

        //x.AddRequestClient<TestMessage>(
        //    new Uri($"rabbitmq://{host}/scr_crt_by_period"), TimeSpan.FromHours(1));
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
