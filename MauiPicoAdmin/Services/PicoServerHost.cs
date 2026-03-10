using MauiPicoAdmin.Controllers;
using PicoServer;
using System.Net;
using System.Reflection;

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
        api.AddStaticFiles("/", wwwrootPath);
        ScanControllers();

        var ws = new WebSocketManager();
        ws.RegisterWebSocket(api);
        // SSE（Server - Sent Events）推送
        api.AddRoute("/iot/notify", HttpHelper.Notify, "GET");
    }

    private void ScanControllers()
    {
        var asm = Assembly.GetExecutingAssembly();
        var controllers = asm.GetTypes().Where(t => t.GetCustomAttribute<ApiControllerAttribute>() != null);
        foreach (var type in controllers)
        {
            var controller = Activator.CreateInstance(type);
            if (controller != null)
            {
                RegisterController(controller);
            }
        }
    }

    private void RegisterController(object controller)
    {

        var methods = controller.GetType().GetMethods();

        foreach (var method in methods)
        {
            var route = method.GetCustomAttribute<ApiRouteAttribute>();

            if (route == null)
                continue;

            RegisterApi(route, controller, method);
        }
    }

    void RegisterApi(ApiRouteAttribute route, object controller, MethodInfo method)
    {
        Func<HttpListenerRequest, HttpListenerResponse, Task> handler = (request, response) =>
        {
            var result = method.Invoke(controller, new object[] { request, response });
            return result as Task ?? Task.CompletedTask;
        };
        api.AddRoute(route.Path, handler, route.Method);
    }
}

