using System;
using System.Threading.Tasks;

namespace PHS.Core.Services
{
    public interface IUserService
    {
        Task<Guid> GetUserIdAsync(string token);
    }
}
