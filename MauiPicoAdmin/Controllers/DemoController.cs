using PicoServer;
using System.Net;

namespace MauiPicoAdmin.Controllers;

public class DemoController
{
    public async Task Hello(HttpListenerRequest request, HttpListenerResponse response)
    {
        await response.WriteAsync("Hello PicoServer");
    }

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

    public async Task GetStatus(HttpListenerRequest request, HttpListenerResponse response)
    {
        await response.WriteAsync("Server Running");
    }

}
