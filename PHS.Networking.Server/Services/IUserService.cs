using System;
using System.Threading;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface IUserService<UId>
    {
        Task<UId> GetIdAsync(string token, CancellationToken cancellationToken = default);
    }
}
