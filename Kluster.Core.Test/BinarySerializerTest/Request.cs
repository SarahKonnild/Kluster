using Kluster.Core.BinarySerializer;
using MessagePack;

namespace Kluster.Core.Test.BinarySerializerTest;

/// <summary>
///   A test request message for serialization.
/// </summary>
[MessagePackObject]
public record Request : IBinarySerializable
{
    /// <summary>
    ///     Just a message.
    /// </summary>
    [Key(0)]
    public required string Message { get; init; }
    
    /// <summary>
    ///     When the message was sent.
    /// </summary>
    [Key(1)]
    public DateTime Sent { get; init; }
}