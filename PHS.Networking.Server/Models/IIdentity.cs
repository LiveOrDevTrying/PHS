using PHS.Networking.Models;

namespace PHS.Networking.Server.Models
{
    public interface IIdentity<T> : IConnection
    {
        T UserId { get; set; }
    }
}
