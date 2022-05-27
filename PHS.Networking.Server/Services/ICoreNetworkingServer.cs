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
    public interface ICoreNetworkingServer<T, U, V, W> : ICoreNetworkingGeneric<T, U, V>
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
        where W : IConnection
    {
        event NetworkingEventHandler<ServerEventArgs> ServerEvent;

        void Start(CancellationToken cancellationToken = default);
        void Stop();

        Task<bool> BroadcastToAllConnectionsAsync(string message, W connectionSending = default, CancellationToken cancellationToken = default);
        Task<bool> SendToConnectionAsync(string message, W connection, CancellationToken cancellationToken = default);
        Task<bool> DisconnectConnectionAsync(W connection, CancellationToken cancellationToken = default);

        IEnumerable<W> Connections { get; }
        int ConnectionCount { get; }
        bool IsServerRunning { get; }
    }
}
