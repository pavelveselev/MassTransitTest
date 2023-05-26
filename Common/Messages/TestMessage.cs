namespace Common.Messages;

public record TestMessage
{
    public int Id { get; set; }

    public DateTime TimeStamp { get; init; }
}
