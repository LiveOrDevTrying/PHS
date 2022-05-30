using PHS.Networking.Events;
using PHS.Networking.Events.Args;
using PHS.Networking.Models;
using PHS.Networking.Server.Events.Args;
using PHS.Networking.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Handlers
{
    public abstract class HandlerServerBase<T, U, V, W, Z> :
        CoreNetworkingGeneric<T, U, V, W, Z>,
        ICoreNetworkingGeneric<T, U, V, Z>
        where T : ConnectionEventArgs<Z>
        where U : MessageEventArgs<Z>
        where V : ErrorEventArgs<Z>
        where W : Params
        where Z : IConnection
    {
        protected readonly byte[] _certificate;
        protected readonly string _certificatePassword;
        protected bool _isRunning;

        protected event NetworkingEventHandler<ServerEventArgs> _serverEvent;

        public HandlerServerBase(W parameters) : base(parameters)
        {
        }

        public HandlerServerBase(W parameters, byte[] certificate, string certificatePassword) : base(parameters)
        {
            _certificate = certificate;
            _certificatePassword = certificatePassword;
        }

        public abstract void Start(CancellationToken cancellationToken = default);
        public abstract void Stop();

        public abstract Task<bool> SendAsync(string message, Z connection, CancellationToken cancellationToken);
        public abstract Task<bool> SendAsync(byte[] message, Z connection, CancellationToken cancellationToken);
        public abstract Task<bool> DisconnectConnectionAsync(Z connection, CancellationToken cancellationToken);

        protected virtual void FireEvent(object sender, ServerEventArgs args)
        {
            _serverEvent?.Invoke(sender, args);
        }

        public bool IsServerRunning
        {
            get
            {
                return _isRunning;
            }
        }

        public event NetworkingEventHandler<ServerEventArgs> ServerEvent
        {
            add
            {
                _serverEvent += value;
            }
            remove
            {
                _serverEvent -= value;
            }
        }
    }
}
