using PHS.Core.Events;
using PHS.Core.Events.Args.NetworkEventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHS.Core.Networking
{
    public interface INetworkClient
    {
        bool IsRunning { get; }

        event NetworkingEventHandler<ConnectionEventArgs> ConnectionEvent;
        event NetworkingEventHandler<ErrorEventArgs> ErrorEvent;

        bool Connect();
        bool Disconnect();

        void Dispose();
    }
}
