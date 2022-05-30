using PHS.Networking.Enums;
using PHS.Core.Events.Args;
using PHS.Networking.Models;

namespace PHS.Networking.Events.Args
{
    public class ConnectionEventArgs<T> : BaseArgs where T : IConnection
    {
        public ConnectionEventType ConnectionEventType { get; set; }
        public T Connection { get; set; }
    }
}
