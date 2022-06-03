using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using PHS.Networking.Server.Events.Args;
using PHS.Networking.Services;
using PHS.Networking.Events;
using System.Collections.Generic;
using PHS.Networking.Models;
using PHS.Networking.Events.Args;
using PHS.Networking.Server.Handlers;
using PHS.Networking.Server.Managers;
using PHS.Networking.Enums;

namespace PHS.Networking.Server.Services
{
    public abstract class CoreNetworkingServer<T, U, V, W, X, Y, Z> :
        CoreNetworkingGeneric<T, U, V, W, Z>
        where T : ConnectionEventArgs<Z>
        where U : MessageEventArgs<Z>
        where V : ErrorEventArgs<Z>
        where W : Params
        where X : HandlerServerBase<T, U, V, W, Z>
        where Y : ConnectionManager<Z>
        where Z : IConnection
    {
        protected readonly X _handler;
        protected readonly Y _connectionManager;
        protected CancellationToken _cancellationToken;

        protected event NetworkingEventHandler<ServerEventArgs> _serverEvent;

        public CoreNetworkingServer(W parameters) : base(parameters)
        {
            _connectionManager = CreateConnectionManager();

            _handler = CreateHandler();
            _handler.ConnectionEvent += OnConnectionEvent;
            _handler.MessageEvent += OnMessageEvent;
            _handler.ErrorEvent += OnErrorEvent;
            _handler.ServerEvent += OnServerEvent;
        }
        public CoreNetworkingServer(W parameters,
            byte[] certificate,
            string certificatePassword) : base(parameters)
        {
            _connectionManager = CreateConnectionManager();

            _handler = CreateHandler(certificate, certificatePassword);
            _handler.ConnectionEvent += OnConnectionEvent;
            _handler.MessageEvent += OnMessageEvent;
            _handler.ErrorEvent += OnErrorEvent;
            _handler.ServerEvent += OnServerEvent;
        }
        public virtual void Start(CancellationToken cancellationToken = default)
        {
            _cancellationToken = cancellationToken;
            _handler.Start(cancellationToken);
        }
        public virtual void Stop()
        {
            _handler.Stop();
        }

        public virtual async Task<bool> BroadcastToAllConnectionsAsync(string message, CancellationToken cancellationToken = default)
        {
            if (IsServerRunning)
            {
                foreach (var connection in _connectionManager.GetAll())
                {
                    await SendToConnectionAsync(message, connection, cancellationToken).ConfigureAwait(false);
                }

                return true;
            }

            return false;
        }
        public virtual async Task<bool> BroadcastToAllConnectionsAsync(byte[] message, CancellationToken cancellationToken = default)
        {
            if (IsServerRunning)
            {
                foreach (var connection in _connectionManager.GetAll())
                {
                    await SendToConnectionAsync(message, connection, cancellationToken).ConfigureAwait(false);
                }

                return true;
            }

            return false;
        }
        public virtual async Task<bool> SendToConnectionAsync(string message, Z connection, CancellationToken cancellationToken = default)
        {
            if (IsServerRunning)
            {
                return await _handler.SendAsync(message, connection, cancellationToken).ConfigureAwait(false);
            }

            return false;
        }
        public virtual async Task<bool> SendToConnectionAsync(byte[] message, Z connection, CancellationToken cancellationToken = default)
        {
            if (IsServerRunning)
            {
                return await _handler.SendAsync(message, connection, cancellationToken).ConfigureAwait(false);
            }

            return false;
        }
        public virtual async Task<bool> DisconnectConnectionAsync(Z connection, CancellationToken cancellationToken = default)
        {
            return await _handler.DisconnectConnectionAsync(connection, cancellationToken).ConfigureAwait(false);
        }

        protected virtual void OnConnectionEvent(object sender, T args)
        {
            switch (args.ConnectionEventType)
            {
                case ConnectionEventType.Connected:
                    _connectionManager.Add(args.Connection.ConnectionId, args.Connection);
                    break;
                case ConnectionEventType.Disconnect:
                    _connectionManager.Remove(args.Connection.ConnectionId);
                    break;
                default:
                    break;
            }

            base.FireEvent(this, args);
        }
        protected virtual void OnServerEvent(object sender, ServerEventArgs args)
        {
            FireEvent(this, args);
        }
        protected virtual void OnMessageEvent(object sender, U args)
        {
            base.FireEvent(this, args);
        }
        protected virtual void OnErrorEvent(object sender, V args)
        {
            base.FireEvent(this, args);
        }

        protected abstract X CreateHandler(byte[] certificate = null, string certificatePassword = null);
        protected abstract Y CreateConnectionManager();

        protected virtual void FireEvent(object sender, ServerEventArgs args)
        {
            _serverEvent?.Invoke(sender, args);
        }

        public override void Dispose()
        {
            foreach (var connection in _connectionManager.GetAll())
            {
                DisconnectConnectionAsync(connection).Wait();
            }

            if (_handler != null)
            {
                _handler.ConnectionEvent -= OnConnectionEvent;
                _handler.MessageEvent -= OnMessageEvent;
                _handler.ErrorEvent -= OnErrorEvent;
                _handler.ServerEvent -= OnServerEvent;
                _handler.Dispose();
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

        public bool IsServerRunning
        {
            get
            {
                return _handler != null ? _handler.IsServerRunning : false;
            }
        }
        public IEnumerable<Z> Connections
        {
            get
            {
                return _connectionManager.GetAll();
            }
        }
        public int ConnectionCount
        {
            get
            {
                return _connectionManager.Count();
            }
        }
    }
}
