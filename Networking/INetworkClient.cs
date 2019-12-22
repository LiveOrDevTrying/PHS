using PHS.Core.Events;
using PHS.Core.Events.Args.NetworkEventArgs;

namespace PHS.Core.Networking
{
    public interface INetworkClient<T, S>
        where T : ConnectionEventArgs
        where S : ErrorEventArgs
    {
        bool IsRunning { get; }

        event NetworkingEventHandler<T> ConnectionEvent;
        event NetworkingEventHandler<S> ErrorEvent;

        void Dispose();
    }
}
