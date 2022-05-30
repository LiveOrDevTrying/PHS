using PHS.Core.Events.Args;
using PHS.Networking.Models;
using System;

namespace PHS.Networking.Events.Args
{
    public class ErrorEventArgs<T> : BaseArgs where T : IConnection
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public T Connection { get; set; }
    }
}
