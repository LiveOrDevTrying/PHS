using System;

namespace PHS.Networking.Models
{
    public interface IPacket
    {
        string Data { get; set; }
        DateTime Timestamp { get; set; }
    }
}