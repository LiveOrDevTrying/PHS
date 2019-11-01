using System;

namespace PHS.Core.Models.DTOs
{
    public struct UserConnectionDTO : IUserConnectionDTO
    {
        public Guid UserId { get; set; }
    }
}
