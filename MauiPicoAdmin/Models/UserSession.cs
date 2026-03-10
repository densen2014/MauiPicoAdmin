namespace MauiPicoAdmin.Models;

public class UserSession
{
    public string? Username { get; set; }

    public string? Role { get; set; }

    public DateTime ExpireTime { get; set; }
}
