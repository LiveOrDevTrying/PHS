using System;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface IUserService<UId>
    {
        Task<bool> IsValidTokenAsync(byte[] token, CancellationToken cancellationToken = default);
        Task<UId> GetIdAsync(byte[] token, CancellationToken cancellationToken = default);
    }
}
