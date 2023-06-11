using PHS.Networking.Models;

namespace PHS.Networking.Server.Models
{
    public interface IConnectionServer : IConnection
    {
        string ConnectionId { get; set; }
    }
}
