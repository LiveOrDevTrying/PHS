using System;

namespace PHS.Core.Models.Networking
{
    public interface INetworkService : IDisposable
    {
        bool IsRunning { get; }
    }
}
