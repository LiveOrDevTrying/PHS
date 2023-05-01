using PHS.Networking.Events.Args;
using PHS.Networking.Server.Models;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface ICoreNetworkingServerAuth<T, U, V, Z, A> : ICoreNetworkingServer<T, U, V, Z>
        where T : ConnectionEventArgs<Z>
        where U : MessageEventArgs<Z>
        where V : ErrorEventArgs<Z>
        where Z : IIdentity<A>
    {
        Task SendToUserAsync(string message, A userId, CancellationToken cancellationToken = default);
        Task SendToUserAsync(byte[] message, A userId, CancellationToken cancellationToken = default);
    }
}
