using PHS.Networking.Events;
using PHS.Networking.Events.Args;
using System;

namespace PHS.Networking.Services
{
    public interface ICoreNetworkingGeneric<T, U, V> : ICoreNetworking
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
    {
        event NetworkingEventHandler<T> ConnectionEvent;
        event NetworkingEventHandler<U> MessageEvent;
        event NetworkingEventHandler<V> ErrorEvent;
    }
}