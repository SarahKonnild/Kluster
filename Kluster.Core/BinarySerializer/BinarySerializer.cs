using MessagePack;

namespace Kluster.Core.BinarySerializer;

/// <summary>
///     Serialize objects to a Kluster-compatible Binary format, using underlying MessagePack implementation.
///     TODO evaluate if needing Async methods too.
/// </summary>
internal static class BinarySerializer
{
    /// <summary>
    ///     Serialize an IBinarySerializable object.
    /// </summary>
    /// <param name="obj">The object to serialize.</param>
    /// <typeparam name="TObject">The type of the object. Must be IBinarySerializable.</typeparam>
    /// <returns>The serialized byte[].</returns>
    internal static byte[] Serialize<TObject>(this TObject obj) where TObject : IBinarySerializable
    {
        return MessagePackSerializer.Serialize(obj);
    }

    /// <summary>
    ///     Deserialize an IBinarySerializable object.
    /// </summary>
    /// <param name="bytes">The binary to deserialize.</param>
    /// <typeparam name="TObject">The type of the object. Must be IBinarySerializable.</typeparam>
    /// <returns>The serialized byte[].</returns>
    internal static TObject Deserialize<TObject>(this byte[] bytes) where TObject : IBinarySerializable
    {
        return MessagePackSerializer.Deserialize<TObject>(bytes);
    }
}