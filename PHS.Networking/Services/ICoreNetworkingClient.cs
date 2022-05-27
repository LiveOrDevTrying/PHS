using PHS.Networking.Events.Args;
using PHS.Networking.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Services
{
    public interface ICoreNetworkingClient<T, U, V, W> : ICoreNetworkingGeneric<T, U, V>
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
        where W : IConnection
    {
        Task<bool> SendAsync(string message, CancellationToken cancellationToken = default);

        Task<bool> ConnectAsync(CancellationToken cancellationToken = default);
        Task<bool> DisconnectAsync(CancellationToken cancellationToken = default);

        bool IsRunning { get; }
        W Connection { get; }
    }
}