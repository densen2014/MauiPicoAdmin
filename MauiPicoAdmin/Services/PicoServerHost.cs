using MauiPicoAdmin.Controllers;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using PicoServer;
using System.Net;

namespace MauiPicoAdmin.Services;

public class PicoServerHost
{
    private readonly WebAPIServer api = new WebAPIServer();

    public PicoServerHost()
    {
        RegisterRoutes();
        api.StartServer();
    }

    private void RegisterRoutes()
    {
        var product = new ProductController();
        api.AddRoute("/", Hello);
        api.AddRoute("/api/time", GetTime);
        api.AddRoute("/api/status", GetStatus);
        api.AddRoute("/api/product/list", product.List);
        api.AddRoute("/api/product/detail", product.Detail);
    }

    private async Task Hello(HttpListenerRequest request, HttpListenerResponse response)
    {
        await response.WriteAsync("Hello PicoServer");
    }

    private async Task GetTime(HttpListenerRequest request, HttpListenerResponse response)
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

    private async Task GetStatus(HttpListenerRequest request, HttpListenerResponse response)
    {
        await response.WriteAsync("Server Running");
    }
}

