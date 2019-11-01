using PHS.Core.Events.Args;
using System.Threading.Tasks;

namespace PHS.Core.Events
{
    public delegate Task NetworkingEventHandler<T>(object sender, T args) where T : BaseArgs;
}
