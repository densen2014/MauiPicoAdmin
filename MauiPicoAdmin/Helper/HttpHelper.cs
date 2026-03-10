using PicoServer;
using System.Net;
using System.Text.Json;

namespace MauiPicoAdmin.Controllers;

public static class HttpHelper
{
    public static async Task WriteJsonAsync(this HttpListenerResponse response, object obj)
    {
        string json = JsonSerializer.Serialize(obj); 
        await response.WriteAsync(json, contentType: "application/json");
    }

}

