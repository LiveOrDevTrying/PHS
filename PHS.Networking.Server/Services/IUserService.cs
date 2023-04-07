using System;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface IUserService<UId>
    {
        Task<bool> IsValidTokenAsync(string token, CancellationToken cancellationToken = default);
        Task<UId> GetIdAsync(string token, CancellationToken cancellationToken = default);
    }
}
