namespace Common.Messages;

public record TestClientMessage
{
    public int Id { get; init; }

    public DateTime TimeStamp { get; init; }
}
