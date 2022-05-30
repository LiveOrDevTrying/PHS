using PHS.Networking.Events;
using PHS.Networking.Events.Args;
using PHS.Networking.Models;

namespace PHS.Networking.Services
{
    public abstract class CoreNetworkingGeneric<T, U, V, W, Z> : ICoreNetworkingGeneric<T, U, V, Z>
        where T : ConnectionEventArgs<Z>
        where U : MessageEventArgs<Z>
        where V : ErrorEventArgs<Z>
        where W : Params
        where Z : IConnection
    {
        private event NetworkingEventHandler<T> _connectionEvent;
        private event NetworkingEventHandler<U> _messageEvent;
        private event NetworkingEventHandler<V> _errorEvent;

        protected readonly W _parameters;

        public CoreNetworkingGeneric(W parameters)
        {
            _parameters = parameters;
        }

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
        public abstract void Dispose();

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
    }
}
