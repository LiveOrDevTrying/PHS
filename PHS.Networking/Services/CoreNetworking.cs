using PHS.Networking.Events;
using PHS.Networking.Events.Args;
using System;
using System.Threading.Tasks;

namespace PHS.Networking.Services
{
    public abstract class CoreNetworking<T, U, V> : IDisposable, ICoreNetworking<T, U, V>
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
    {
        private event NetworkingEventHandler<T> _connectionEvent;
        private event NetworkingEventHandler<U> _messageEvent;
        private event NetworkingEventHandler<V> _errorEvent;

        protected virtual async Task FireEventAsync(object sender, T args)
        {
            await _connectionEvent?.Invoke(sender, args);
        }
        protected virtual async Task FireEventAsync(object sender, U args)
        {
            await _messageEvent?.Invoke(sender, args);
        }
        protected virtual async Task FireEventAsync(object sender, V args)
        {
            await _errorEvent?.Invoke(sender, args);
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
    }
}
