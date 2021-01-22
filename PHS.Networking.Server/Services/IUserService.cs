using System;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface IUserService<UId>
    {
        Task<bool> IsValidTokenAsync(string token);
        Task<UId> GetIdAsync(string token);
    }
}
