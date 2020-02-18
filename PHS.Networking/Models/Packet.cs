using System;

namespace PHS.Networking.Models
{
    public struct Packet : IPacket
    {
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
}