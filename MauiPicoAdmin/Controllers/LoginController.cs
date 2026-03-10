using MauiPicoAdmin.Models;
using System.Net;
using System.Text.Json;

namespace MauiPicoAdmin.Controllers;

[ApiController]
public partial class LoginController
{

    //private readonly JsonSerializerOptions _jsonOptions;

    //public LoginController(JsonSerializerOptions jsonOptions)
    //{
    //    _jsonOptions = jsonOptions;
    //}

    [ApiRoute("/api/login")]
    public async Task Login(HttpListenerRequest request, HttpListenerResponse response)
    {
        var body = await new StreamReader(request.InputStream).ReadToEndAsync();

        //var login = JsonSerializer.Deserialize<LoginRequest>(body, _jsonOptions);
        var login = JsonSerializer.Deserialize<LoginRequest>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (login != null && login.Username == "admin" && login.Password == "123456")
        {
            var token = TokenService.GenerateToken(login.Username);

            await response.WriteJsonAsync(new
            {
                success = true,
                token = token
            });
        }
        else
        {
            response.StatusCode = 401;

            await response.WriteJsonAsync(new
            {
                success = false,
                message = "Invalid username or password"
            });
        }
    }
}

