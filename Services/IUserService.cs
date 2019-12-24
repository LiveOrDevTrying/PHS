using System;
using System.Threading.Tasks;

namespace PHS.Core.Services
{
    public interface IUserService : IDisposable
    {
        Task<Guid> GetUserIdAsync(string token);
    }
}
