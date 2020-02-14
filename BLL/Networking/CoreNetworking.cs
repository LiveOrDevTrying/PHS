using PHS.Core.Events;
using PHS.Core.Events.Args.Networking;
using System;

namespace PHS.Core.BLL.Networking
{
    public abstract class CoreNetworking<T, U, V, W> : IDisposable, ICoreNetworking<T, U, V, W>
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
        where W : ServerEventArgs
    {
        protected string _endOfLineCharacters;

        private NetworkingEventHandler<T> _connectionEvent;
        private NetworkingEventHandler<U> _messageEvent;
        private NetworkingEventHandler<V> _errorEvent;
        private NetworkingEventHandler<W> _serverEvent;

        protected virtual void FireEvent(object sender, T args)
        {
            _connectionEvent?.Invoke(sender, args);
        }
        protected virtual void FireEvent(object sender, U args)
        {
            _messageEvent?.Invoke(sender, args);
        }
        protected virtual void FireEvent(object sender, V args)
        {
            _errorEvent?.Invoke(sender, args);
        }
        protected virtual void FireEvent(object sender, W args)
        {
            _serverEvent?.Invoke(sender, args);
        }
        public virtual void Dispose()
        { }

        public event NetworkingEventHandler<T> ConnectionEvent
        {
            add
            {
                _connectionEvent += value;
            }
            remove
            {
                _connectionEvent -= value;
            }
        }
        public event NetworkingEventHandler<U> MessageEvent
        {
            add
            {
                _messageEvent += value;
            }
            remove
            {
                _messageEvent -= value;
            }
        }
        public event NetworkingEventHandler<V> ErrorEvent
        {
            add
            {
                _errorEvent += value;
            }
            remove
            {
                _errorEvent -= value;
            }
        }
        public event NetworkingEventHandler<W> ServerEvent
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
