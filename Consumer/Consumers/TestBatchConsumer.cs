using Common.Messages;
using MassTransit;

namespace Consumer.Consumers;

public class TestBatchConsumer : IConsumer<Batch<TestBatchMessage>>
{
    public async Task Consume(ConsumeContext<Batch<TestBatchMessage>> context)
    {
        Console.WriteLine($"Messages count: {context.Message.Count()}. Message ids: [{string.Join(",", context.Message.Select(x => x.Message.Id))}]");
    }
}
