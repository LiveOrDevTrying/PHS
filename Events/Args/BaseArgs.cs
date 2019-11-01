using PHS.Core.Enums;
using System;

namespace PHS.Core.Events.Args
{
    public class BaseArgs
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ArgsType ArgsType { get; set; }

        public T GetType<T>() where T : BaseArgs
        {
            return this as T;
        }
    }
}
