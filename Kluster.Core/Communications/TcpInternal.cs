using Kluster.Core.Client;
using Microsoft.Extensions.Logging;

namespace Kluster.Core.Communications;

public class TcpInternal(ILogger<TcpInternal> logger, IClientFactory clientFactory) : IInternalCommunications
{
    /// <inheritdoc />
    public void PublishToClient<T>(string key, T message)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
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