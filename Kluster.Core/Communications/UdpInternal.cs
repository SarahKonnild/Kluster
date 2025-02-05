using Kluster.Core.Client;
using Microsoft.Extensions.Logging;

namespace Kluster.Core.Communications;

public class UdpInternal(ILogger<UdpInternal> logger, IClientFactory clientFactory) : IInternalCommunications
{
    /// <inheritdoc />
    public void PublishToClient<T>(string key, T message)
    {
        throw new NotImplementedException();
    }

    public void PublishToAllClients<T>(T message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public T Receive<T>()
    {
        throw new NotImplementedException();
    }
}