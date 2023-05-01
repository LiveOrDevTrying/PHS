using PHS.Networking.Models;

namespace PHS.Networking.Server.Models
{
    public interface IIdentity<T> : IConnection
    {
        public T UserId { get; set; }
    }
}
