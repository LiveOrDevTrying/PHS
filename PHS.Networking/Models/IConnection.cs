using System;

namespace PHS.Networking.Models
{
    public interface IConnection : IDisposable
    {
        string ConnectionId { get; set; }
    }
}
