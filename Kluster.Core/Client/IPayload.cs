using Kluster.Core.BinarySerializer;

namespace Kluster.Core.Client;

/// <summary>
///     An IPayload implementing class is a message object that can be transferred between a Kluster Client and Server.
///     It defines a method to call on the receiving end, and a serializable payload.
///     Therefore, each IPayload must be IBinarySerializable as well.
/// </summary>
public abstract class IPayload : IBinarySerializable
{
    /// <summary>
    ///     The enum value of the interface-defined method to call.
    /// </summary>
    public int Method { get; set; }
    
    /// <summary>
    ///     The nullable payload object/message that must be transferred to the receiver.
    /// </summary>
    public object? Payload { get; set; }
}