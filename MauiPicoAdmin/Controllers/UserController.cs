using System.Net;
using static MauiPicoAdmin.AuthMiddleware;

namespace MauiPicoAdmin.Controllers;

public class UserController
{
    public async Task GetUserList(HttpListenerRequest request, HttpListenerResponse response)
    {
        if (!await RequireAuth(request, response))
            return;

        var users = new[]
        {
            new { id = 1, name = "admin" },
            new { id = 2, name = "operator" }
        };

        await response.WriteJsonAsync(users);
    }

}
