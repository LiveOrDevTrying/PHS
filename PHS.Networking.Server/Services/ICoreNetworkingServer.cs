using PHS.Networking.Events;
using PHS.Networking.Events.Args;
using PHS.Networking.Models;
using PHS.Networking.Server.Events.Args;
using PHS.Networking.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface ICoreNetworkingServer<T, U, V, Z> : ICoreNetworkingGeneric<T, U, V, Z>
        where T : ConnectionEventArgs<Z>
        where U : MessageEventArgs<Z>
        where V : ErrorEventArgs<Z>
        where Z : IConnection
    {
        event NetworkingEventHandler<ServerEventArgs> ServerEvent;

        Task StartAsync(CancellationToken cancellationToken = default);
        Task StopAsync(CancellationToken cancellation = default);

        Task<bool> BroadcastToAllConnectionsAsync(string message, CancellationToken cancellationToken = default);
        Task<bool> BroadcastToAllConnectionsAsync(byte[] message, CancellationToken cancellationToken = default);
        Task<bool> SendToConnectionAsync(string message, Z connection, CancellationToken cancellationToken = default);
        Task<bool> SendToConnectionAsync(byte[] message, Z connection, CancellationToken cancellationToken = default);
        Task<bool> DisconnectConnectionAsync(Z connection, CancellationToken cancellationToken = default);

        IEnumerable<Z> Connections { get; }
        int ConnectionCount { get; }
        bool IsServerRunning { get; }
    }
}
