using PHS.Networking.Enums;
using PHS.Core.Events.Args;

namespace PHS.Networking.Events.Args
{
    public class ConnectionEventArgs : BaseArgs
    {
        public ConnectionEventType ConnectionEventType { get; set; }
    }
}
