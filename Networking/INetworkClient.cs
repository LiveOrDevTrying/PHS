using System;

namespace PHS.Core.Networking
{
    public interface INetworkClient : IDisposable
    {
        bool IsRunning { get; }
    }
}
