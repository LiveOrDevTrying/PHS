using PHS.Networking.Events.Args;
using PHS.Networking.Handlers;
using PHS.Networking.Models;
using PHS.Networking.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Services
{
    public abstract class CoreNetworkingClient<T, U, V, W, X, Y> : 
        CoreNetworkingGeneric<T, U, V, W, Y>,
        ICoreNetworkingClient<T, U, V, Y>
        where T : ConnectionEventArgs<Y>
        where U : MessageEventArgs<Y>
        where V : ErrorEventArgs<Y>
        where W : IParams
        where X : HandlerClientBase<T, U, V, W, Y>
        where Y : IConnection
    {
        protected readonly X _handler;

        public CoreNetworkingClient(W parameters) : base(parameters)
        {
            _handler = CreateTcpClientHandler();
            _handler.ConnectionEvent += OnConnectionEvent;
            _handler.MessageEvent += OnMessageEvent;
            _handler.ErrorEvent += OnErrorEvent;
        }

        public virtual async Task<bool> ConnectAsync(CancellationToken cancellationToken = default)
        {
            return await _handler.ConnectAsync(cancellationToken).ConfigureAwait(false);
        }
        public virtual async Task<bool> DisconnectAsync(CancellationToken cancellationToken = default)
        {
            return await _handler.DisconnectAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<bool> SendAsync(string message, CancellationToken cancellationToken = default)
        {
            return await _handler.SendAsync(message, cancellationToken).ConfigureAwait(false);
        }
        public virtual async Task<bool> SendAsync(byte[] message, CancellationToken cancellationToken = default)
        {
            return await _handler.SendAsync(message, cancellationToken).ConfigureAwait(false);
        }

        protected virtual void OnConnectionEvent(object sender, T args)
        {
            FireEvent(this, args);
        }
        protected virtual void OnMessageEvent(object sender, U args)
        {
            FireEvent(this, args);
        }
        protected virtual void OnErrorEvent(object sender, V args)
        {
            FireEvent(this, args);
        }

        protected abstract X CreateTcpClientHandler();

        public override void Dispose()
        {
            if (_handler != null)
            {
                _handler.ConnectionEvent -= OnConnectionEvent;
                _handler.MessageEvent -= OnMessageEvent;
                _handler.ErrorEvent -= OnErrorEvent;
                _handler.Dispose();
            }
        }

        public Y Connection
        {
            get
            {
                return _handler.Connection;
            }
        }
    }
}
