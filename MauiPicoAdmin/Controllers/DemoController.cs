using PicoServer;
using System.Net;

namespace MauiPicoAdmin.Controllers;

[ApiController]
public class DemoController
{
    [ApiRoute("/api/hello")]
    public async Task Hello(HttpListenerRequest request, HttpListenerResponse response)
    {
        await response.WriteAsync("Hello PicoServer");
    }

    [ApiRoute("/api/time")]
    public async Task GetTime(HttpListenerRequest request, HttpListenerResponse response)
    {
        var result = new
        {
            code = 0,
            message = "ok",
            data = new
            {
                time = DateTime.Now
            }
        };

        string json = System.Text.Json.JsonSerializer.Serialize(result);

        response.ContentType = "application/json";
        await response.WriteAsync(json);
    }

    [ApiRoute("/api/status")]
    public async Task GetStatus(HttpListenerRequest request, HttpListenerResponse response)
    {
        await response.WriteAsync("Server Running");
    }

}
