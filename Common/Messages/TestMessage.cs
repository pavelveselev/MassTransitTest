﻿namespace Common.Messages;

public record TestMessage
{
    public int Id { get; init; }

    public DateTime TimeStamp { get; init; }
}
