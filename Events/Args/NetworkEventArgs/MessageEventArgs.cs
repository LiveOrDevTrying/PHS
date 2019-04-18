using PHS.Core.Enums;
using PHS.Core.Models.DTOs;

namespace PHS.Core.Events.Args.NetworkEventArgs
{
    public class MessageEventArgs : BaseArgs
    {
        public MessageEventType MessageEventType { get; set; }
        public string Message { get; set; }
    }
}
