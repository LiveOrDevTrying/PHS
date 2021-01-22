using PHS.Networking.Models;
using System.Collections.Generic;
using System.Net.Sockets;

namespace PHS.Networking.Server.Models
{
    public interface IUserConnections<UId, Connection> where Connection : IConnection
    {
        public UId UserId { get; set; }

        ICollection<Connection> Connections { get; set; }
    }
}
