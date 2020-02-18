using System;

namespace PHS.Networking.Server.Models
{
    public interface IUser<T>
    {
        T Id { get; set; }
    }
}