using Common.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class TestClientConsumer : IConsumer<TestClientMessage>
{
    public async Task Consume(ConsumeContext<TestClientMessage> context)
    {
        Console.WriteLine($"Received message {context.Message.Id}. TimeStamp {context.Message.TimeStamp}. Time: {DateTime.Now} Handling...");

        await Task.Delay(TimeSpan.FromSeconds(3));

        await context.RespondAsync(new TestClientResultMessage
        {
            Result = string.Empty,
        });

        Console.WriteLine($"Received message {context.Message.Id}. TimeStamp {context.Message.TimeStamp}. Time: {DateTime.Now}. Handled.");
    }
}
