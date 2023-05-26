namespace Common.Messages;

public record TestClientResultMessage : ITestClientResultMessage
{
    public string Result { get; init; }
}