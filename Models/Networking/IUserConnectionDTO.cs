using System;

namespace PHS.Core.Models.Networking
{
    public interface IUserConnectionDTO<T>
    {
        T UserId { get; set; }
    }
}