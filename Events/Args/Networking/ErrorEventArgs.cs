using System;

namespace PHS.Core.Events.Args.Networking
{
    public class ErrorEventArgs : BaseArgs
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
