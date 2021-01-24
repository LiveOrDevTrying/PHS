﻿using PHS.Networking.Models;
using System.Collections.Generic;

namespace PHS.Networking.Server.Models
{
    public interface IUserConnections<UId, Connection> where Connection : IConnection
    {
        public UId UserId { get; set; }

        ICollection<Connection> Connections { get; set; }
    }
}
