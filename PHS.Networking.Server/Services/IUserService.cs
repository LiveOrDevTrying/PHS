﻿using System;
using System.Threading.Tasks;

namespace PHS.Networking.Server.Services
{
    public interface IUserService<T> : IDisposable
    {
        Task<bool> IsValidTokenAsync(string token);
        Task<T> GetIdAsync(string token);
    }
}
