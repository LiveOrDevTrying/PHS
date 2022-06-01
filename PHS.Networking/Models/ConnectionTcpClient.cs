using System.Net.Sockets;

namespace PHS.Networking.Models
{
    public class ConnectionTcpClient : IConnection
    {
        public TcpClient TcpClient { get; set; }
        public string ConnectionId { get; set; }
    }
}
