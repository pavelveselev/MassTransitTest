using Common.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class TestConsumer : IConsumer<TestMessage>
{
    public async Task Consume(ConsumeContext<TestMessage> context)
    {
        Console.WriteLine($"Received message {context.Message.Id}. TimeStamp {context.Message.TimeStamp}. Time: {DateTime.Now} Handling...");

        await Task.Delay(TimeSpan.FromSeconds(3));

        Console.WriteLine($"Received message {context.Message.Id}. TimeStamp {context.Message.TimeStamp}. Time: {DateTime.Now}. Handled.");
    }
}
