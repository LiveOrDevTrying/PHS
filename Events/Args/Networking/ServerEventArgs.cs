using PHS.Core.Enums;

namespace PHS.Core.Events.Args.Networking
{
    public class ServerEventArgs : BaseArgs
    {
        public ServerEventType ServerEventType { get; set; }
    }
}
