namespace Kluster.Core.Communications;

public interface IInternalCommunications
{
    public void PublishToClient<T>(string key, T message);
    public void PublishToAllClients<T>(T message);
    public T Receive<T>();
}