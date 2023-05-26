namespace Common.Messages;

public record TestBatchMessage
{
    public int Id { get; init; }

    public DateTime TimeStamp { get; init; }
}
