using PHS.Core.Enums;

namespace PHS.Core.Events.Args.Networking
{
    public class ConnectionEventArgs : BaseArgs
    {
        public ConnectionEventType ConnectionEventType { get; set; }
    }
}
