namespace PHS.Networking.Server.Models
{
    public interface IIdentity<UId>
    {
        UId UserId { get; set; }
    }
}
