using PHS.Core.Events.Args;
using System.Threading.Tasks;

namespace PHS.Networking.Events
{
    public delegate void NetworkingEventHandler<T>(object sender, T args) where T : BaseArgs;
}
