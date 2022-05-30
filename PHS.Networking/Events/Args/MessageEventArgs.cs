using PHS.Core.Events.Args;
using PHS.Networking.Enums;
using PHS.Networking.Models;

namespace PHS.Networking.Events.Args
{
    public class MessageEventArgs<T> : BaseArgs where T : IConnection
    {
        public MessageEventType MessageEventType { get; set; }
        public byte[] Bytes { get; set; }
        public T Connection { get; set; }
    }
}
