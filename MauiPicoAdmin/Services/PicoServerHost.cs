using MauiPicoAdmin.Controllers;
using PicoServer;

namespace MauiPicoAdmin.Services;

public class PicoServerHost
{
    private readonly WebAPIServer api = new WebAPIServer();
    public readonly string wwwrootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");

    public PicoServerHost()
    {
        FileHelper.EnsureWwwrootExistsAsync().Wait();
        RegisterRoutes();
        api.StartServer();
    }

    private void RegisterRoutes()
    {
        var product = new ProductController();
        var demo = new DemoController();
        api.AddStaticFiles("/", wwwrootPath);
        api.AddRoute("/api/hello", demo.Hello);
        api.AddRoute("/api/time", demo.GetTime);
        api.AddRoute("/api/status", demo.GetStatus);
        api.AddRoute("/api/product/list", product.List);
        api.AddRoute("/api/product/detail", product.Detail); 
    }

}

