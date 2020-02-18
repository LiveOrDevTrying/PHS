using PHS.Core.Events.Args;
using System.Threading.Tasks;

namespace PHS.Networking.Events
{
    public delegate Task NetworkingEventHandler<T>(object sender, T args) where T : BaseArgs;
}
