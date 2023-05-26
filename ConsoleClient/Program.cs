// See https://aka.ms/new-console-template for more information
using Common.Messages;
using MassTransit;

Console.WriteLine("Start");


IBusControl bus = Bus.Factory.CreateUsingRabbitMq(config =>
{
    EndpointConvention.Map<TestBatchMessage>(new Uri($"queue:test_batch_queue"));

    config.Host(new Uri("rabbitmq://localhost"), c =>
    {
        c.Username("guest");
        c.Password("guest");
    });
});

//bus.Start();
int count = 0;
foreach (var i in Enumerable.Range(0, 1000))
{
    var message = new TestBatchMessage
    {
        Id = count++,
        TimeStamp = DateTime.Now,
    };
    await bus.Send(message);
}

Console.ReadLine();

//bus.Stop();