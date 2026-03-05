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
        //第三个参数 "/api/" 不合理，但目前 PicoServer 的 AddStaticFiles 方法没有提供更合理的方式来处理静态文件和 API 路由的冲突问题，所以暂时只能这样做
        api.AddStaticFiles("/", wwwrootPath, "/api/");
        api.AddRoute("/api/hello", demo.Hello);
        api.AddRoute("/api/time", demo.GetTime);
        api.AddRoute("/api/status", demo.GetStatus);
        api.AddRoute("/api/product/list", product.List);
        api.AddRoute("/api/product/detail", product.Detail); 
    }

}

