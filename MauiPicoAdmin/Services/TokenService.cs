using MauiPicoAdmin.Models;

namespace MauiPicoAdmin.Services;

public class TokenService
{
    static Dictionary<string, UserSession> sessions = new();

    public static string GenerateToken(string username)
    {
        var token = Guid.NewGuid().ToString();

        sessions[token] = new UserSession
        {
            Username = username,
            Role = "admin",
            ExpireTime = DateTime.Now.AddHours(12)
        };

        return token;
    }

    public static UserSession? Validate(string token)
    {
        if (!sessions.ContainsKey(token))
            return null;

        var session = sessions[token];

        if (session.ExpireTime < DateTime.Now)
            return null;

        return session;
    }
}
