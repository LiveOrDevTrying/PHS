using PHS.Networking.Events.Args;
using PHS.Networking.Models;
using PHS.Networking.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Handlers
{
    public abstract class HandlerClientBase<T, U, V, W, Y> :
        CoreNetworkingGeneric<T, U, V, W, Y>,
        ICoreNetworkingGeneric<T, U, V, Y>
        where T : ConnectionEventArgs<Y>
        where U : MessageEventArgs<Y>
        where V : ErrorEventArgs<Y>
        where W : IParams
        where Y : IConnection
    {
        protected Y _connection;
        protected bool _isRunning;

        public HandlerClientBase(W parameters) : base(parameters)
        {
        }

        public abstract Task<bool> ConnectAsync(CancellationToken cancellationToken = default);
        public abstract Task<bool> DisconnectAsync(CancellationToken cancellationToken = default);

        public abstract Task<bool> SendAsync(string message, CancellationToken cancellationToken);
        public abstract Task<bool> SendAsync(byte[] message, CancellationToken cancellationToken);

        public override void Dispose()
        {
            _connection?.Dispose();
        }

        public Y Connection
        {
            get
            {
                return _connection;
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }
    }
}
