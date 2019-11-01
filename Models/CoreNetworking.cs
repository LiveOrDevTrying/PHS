using PHS.Core.Events;
using PHS.Core.Events.Args.NetworkEventArgs;
using System;

namespace PHS.Core.Models
{
    public abstract class CoreNetworking<T, U, V> : IDisposable, ICoreNetworking<T, U, V>
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
    {
        protected string _endOfLineCharacters;

        private NetworkingEventHandler<T> _connectionEvent;
        private NetworkingEventHandler<U> _messageEvent;
        private NetworkingEventHandler<V> _errorEvent;

        protected virtual void FireEvent(object sender, T e)
        {
            _connectionEvent?.Invoke(sender, e);
        }
        protected virtual void FireEvent(object sender, U e)
        {
            _messageEvent?.Invoke(sender, e);
        }
        protected virtual void FireEvent(object sender, V e)
        {
            _errorEvent?.Invoke(sender, e);
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
