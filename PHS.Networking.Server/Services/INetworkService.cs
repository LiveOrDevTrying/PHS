using System;

namespace PHS.Networking.Server.Services
{
    public interface INetworkService : IDisposable
    {
        bool IsRunning { get; }
    }
}
