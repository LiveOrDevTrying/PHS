using System;
using System.Threading.Tasks;

namespace PHS.Core.BLL.Users
{
    public interface IUserService<T> : IDisposable
    {
        Task<T> GetUserIdAsync(string token);
    }
}
