using System;

namespace PHS.Core.Models.Networking
{
    public struct PacketDTO
    {
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
}