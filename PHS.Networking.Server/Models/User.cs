namespace PHS.Networking.Server.Models
{
    public class User<T> : IUser<T>
    {
        public T Id { get; set; }
    }
}
