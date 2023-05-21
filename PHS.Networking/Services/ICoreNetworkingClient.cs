using PHS.Networking.Events.Args;
using PHS.Networking.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Services
{
    public interface ICoreNetworkingClient<T, U, V, W> : ICoreNetworkingGeneric<T, U, V, W>
        where T : ConnectionEventArgs<W>
        where U : MessageEventArgs<W>
        where V : ErrorEventArgs<W>
        where W : IConnection
    {
        Task<bool> SendAsync(string message, CancellationToken cancellationToken = default);
        Task<bool> SendAsync(byte[] message, CancellationToken cancellationToken = default);

        Task<bool> ConnectAsync(CancellationToken cancellationToken = default);
        Task<bool> DisconnectAsync(CancellationToken cancellationToken = default);

        W Connection { get; }
    }
}