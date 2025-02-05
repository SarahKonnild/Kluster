using Kluster.Core.BinarySerializer;

namespace Kluster.Core.Test.BinarySerializerTest;

public class BinarySerializerTest
{
    [Fact]
    public void Should_SerializeRequestObject_When_Serializing()
    {
        // ARRANGE
        var requestMessage = new Request
        {
            Message = "Hello, I am a message.",
            Sent = DateTime.UtcNow
        };

        // ACT
        var serializedRequest = requestMessage.Serialize();

        // ASSERT
        Assert.Equal(34, serializedRequest.Length);
    }

    [Fact]
    public void Should_DeserializeRequestObject_When_Deserializing()
    {
        // ARRANGE
        byte[] serializedRequest = [146, 182, 72, 101, 108, 108, 111, 44, 32, 73, 32, 97, 109, 32, 97, 32, 109, 101, 115, 115, 97, 103, 101, 46, 215, 255, 227, 251, 237, 160, 103, 163, 140, 19];
        
        // ACT
        var deserializedRequest = serializedRequest.Deserialize<Request>();

        // ASSERT
        Assert.Equal("Hello, I am a message.", deserializedRequest.Message);
        Assert.Equal(DateTime.Parse("2025-02-05T16:04:35.9562346Z").ToUniversalTime(), deserializedRequest.Sent);
    }
}