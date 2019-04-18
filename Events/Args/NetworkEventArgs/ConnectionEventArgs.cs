using PHS.Core.Enums;

namespace PHS.Core.Events.Args.NetworkEventArgs
{
    public class ConnectionEventArgs : BaseArgs
    {
        public ConnectionEventType ConnectionEventType { get; set; }
    }
}
