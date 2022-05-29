using PHS.Networking.Models;
using System;

namespace Tcp.NET.Server.Events.Args
{
    public class AuthorizeBaseEventArgs<T> : EventArgs where T : IConnection
    {
        public T Connection { get; set; }
        public string Token { get; set; }
    }
}

