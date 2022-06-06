using System;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface IUserService<UId>
    {
        Task<bool> TryGetIdAsync(string token, out UId id, CancellationToken cancellationToken = default);
    }
}
