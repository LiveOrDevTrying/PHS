using PHS.Core.Events;
using PHS.Core.Events.Args.NetworkEventArgs;
using System;

namespace PHS.Core.Models
{
    public interface ICoreNetworking<T, U, V> : IDisposable
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
    {
        event NetworkingEventHandler<T> ConnectionEvent;
        event NetworkingEventHandler<U> MessageEvent;
        event NetworkingEventHandler<V> ErrorEvent;
    }
}