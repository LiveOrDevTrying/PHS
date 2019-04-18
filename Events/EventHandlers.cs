using PHS.Core.Events.Args;

namespace PHS.Core.Events
{
    public delegate void NetworkingEventHandler<T>(object sender, T e) where T : BaseArgs;
}
