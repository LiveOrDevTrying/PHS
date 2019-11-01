using System;

namespace PHS.Core.Models
{
    public struct UserConnectionDTO : IUserConnectionDTO
    {
        public Guid UserId { get; set; }
    }
}
