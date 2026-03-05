using MauiPicoAdmin.Models;
using PicoServer;
using System.Net;
using System.Text.Json;

namespace MauiPicoAdmin.Controllers;

public class ProductController
{
    private ProductService service = new ProductService();

    public async Task List(HttpListenerRequest request, HttpListenerResponse response)
    {
        var data = service.GetProducts();

        var result = ApiResult.Success(data);

        string json = JsonSerializer.Serialize(result);

        response.ContentType = "application/json";
        await response.WriteAsync(json);
    }

    public async Task Detail(HttpListenerRequest request, HttpListenerResponse response)
    {
        string? id = request.QueryString["id"];

        var data = service.GetProduct(id);

        var result = ApiResult.Success(data);

        string json = JsonSerializer.Serialize(result);

        response.ContentType = "application/json";
        await response.WriteAsync(json);
    }
}
