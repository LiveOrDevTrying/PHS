using PHS.Networking.Models;

namespace PHS.Networking.Server.Models
{
    public interface IIdentity<UId> : IConnection
    {
        UId UserId { get; set; }
    }
}
