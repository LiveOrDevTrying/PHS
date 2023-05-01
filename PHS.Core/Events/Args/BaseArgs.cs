using System;
using System.Threading;

namespace PHS.Core.Events.Args
{
    public abstract class BaseArgs : EventArgs
    {
        public CancellationToken CancellationToken { get; set; }
    }
}
