using MauiPicoAdmin.Models;
using System.Net;

namespace MauiPicoAdmin;

public class AuthMiddleware
{
    public static UserSession? Authenticate(HttpListenerRequest request)
    {
        var token = request.Headers["Authorization"];

        if (string.IsNullOrEmpty(token))
            return null;

        return TokenService.Validate(token);
    }

    public static async Task<bool> RequireAuth(
        HttpListenerRequest request,
        HttpListenerResponse response)
    {
        var session = AuthMiddleware.Authenticate(request);

        if (session == null)
        {
            response.StatusCode = 401;

            await response.WriteJsonAsync(new
            {
                message = "Unauthorized"
            });

            return false;
        }

        return true;
    }
}
