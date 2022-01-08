using PHS.Core.Events.Args;
using PHS.Networking.Enums;
using PHS.Networking.Models;

namespace PHS.Networking.Events.Args
{
    public class MessageEventArgs : BaseArgs
    {
        public MessageEventType MessageEventType { get; set; }
        public IPacket Packet { get; set; }
    }
}
