using PHS.Core.Enums;

namespace PHS.Core.Events.Args.NetworkEventArgs
{
    public class MessageEventArgs : BaseArgs
    {
        public MessageEventType MessageEventType { get; set; }
        public string Message { get; set; }
    }
}
