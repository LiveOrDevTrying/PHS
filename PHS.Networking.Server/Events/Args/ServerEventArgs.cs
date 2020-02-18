using PHS.Core.Events.Args;
using PHS.Networking.Server.Enums;

namespace PHS.Networking.Server.Events.Args
{
    public class ServerEventArgs : BaseArgs
    {
        public ServerEventType ServerEventType { get; set; }
    }
}
