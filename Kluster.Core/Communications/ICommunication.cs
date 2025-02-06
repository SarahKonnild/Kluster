namespace Kluster.Core.Communications;

/// <summary>
///     A marker interface for the interface definitions that are used to define the receiving points of an application
///     for import in the using side.
///     I.e. An IServer is defined which implements ICommunication, the IServer interface defines [UdpEndpoint] and
///     [TcpEndpoint] which the Clients can use to reach the server. Each different type of Endpoint generates its own
///     method which applies the correct transfer protocol.
/// </summary>
public interface ICommunication;