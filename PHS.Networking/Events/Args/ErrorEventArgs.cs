using PHS.Core.Events.Args;
using System;

namespace PHS.Networking.Events.Args
{
    public class ErrorEventArgs : BaseArgs
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
