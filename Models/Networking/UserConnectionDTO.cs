namespace PHS.Core.Models.Networking
{
    public class UserConnectionDTO<T> : IUserConnectionDTO<T>
    {
        public T UserId { get; set; }
    }
}
