using Common.Messages;
using Consumer.Consumers;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
            {
                x.AddConsumer<TestClientConsumer>();
                x.AddConsumer<TestBatchConsumer>();
                x.AddConsumer<TestConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    var messageLimit = 5;
                    cfg.ReceiveEndpoint("test_batch_queue", e =>
                    {
                        e.PrefetchCount = messageLimit;
                        e.Batch<TestBatchMessage>(b =>
                        {
                            b.MessageLimit = messageLimit;
                            b.ConcurrencyLimit = 1;
                            b.TimeLimit = TimeSpan.FromSeconds(5);
                            b.Consumer(() => new TestBatchConsumer());
                        });
                    });

                    cfg.ReceiveEndpoint("test_client_queue", e =>
                    {
                        e.ConfigureConsumer<TestClientConsumer>(context);
                    });

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
