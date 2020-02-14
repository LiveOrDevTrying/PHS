using PHS.Core.Events;
using PHS.Core.Events.Args.Networking;
using System;

namespace PHS.Core.BLL.Networking
{
    public interface ICoreNetworking<T, U, V, W> : IDisposable
        where T : ConnectionEventArgs
        where U : MessageEventArgs
        where V : ErrorEventArgs
        where W : ServerEventArgs
    {
        event NetworkingEventHandler<T> ConnectionEvent;
        event NetworkingEventHandler<U> MessageEvent;
        event NetworkingEventHandler<V> ErrorEvent;
        event NetworkingEventHandler<W> ServerEvent;
    }
}