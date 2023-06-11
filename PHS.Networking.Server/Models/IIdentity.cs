using PHS.Networking.Models;

namespace PHS.Networking.Server.Models
{
    public interface IIdentity<T> : IConnectionServer
    {
        T UserId { get; set; }
    }
}
