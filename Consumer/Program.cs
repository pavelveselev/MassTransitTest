using Consumer.Consumers;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
            {
                x.AddConsumer<TestConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("test_queue", e =>
                    {
                        e.ConfigureConsumer<TestConsumer>(context);
                    });
                });
            }
        );
    })
    .Build();

host.Run();
