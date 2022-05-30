using PHS.Networking.Events;
using PHS.Networking.Events.Args;
using PHS.Networking.Models;
using System;

namespace PHS.Networking.Services
{
    public interface ICoreNetworkingGeneric<T, U, V, Z> : ICoreNetworking
        where T : ConnectionEventArgs<Z>
        where U : MessageEventArgs<Z>
        where V : ErrorEventArgs<Z>
        where Z : IConnection
    {
        event NetworkingEventHandler<T> ConnectionEvent;
        event NetworkingEventHandler<U> MessageEvent;
        event NetworkingEventHandler<V> ErrorEvent;
    }
}