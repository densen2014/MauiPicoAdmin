using PicoServer;
using System.Net;
using System.Text.Json;

namespace MauiPicoAdmin.Controllers;

public static class HttpHelper
{
    public static async Task WriteJson(this HttpListenerResponse response, object obj)
    {
        string json = JsonSerializer.Serialize(obj);

        response.ContentType = "application/json";

        await response.WriteAsync(json);
    }

}

