using PHS.Core.Events.Args;
using PHS.Networking.Enums;

namespace PHS.Networking.Events.Args
{
    public class MessageEventArgs : BaseArgs
    {
        public MessageEventType MessageEventType { get; set; }
    }
}
