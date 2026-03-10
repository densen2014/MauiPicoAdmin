using MauiPicoAdmin.Models;
using System.Net;

namespace MauiPicoAdmin.Controllers;

public class ProductController
{
    private ProductService service = new ProductService();

    public async Task List(HttpListenerRequest request, HttpListenerResponse response)
    {
        var data = service.GetProducts();

        var result = ApiResult.Success(data);

        await response.WriteJsonAsync(result);
    }

    public async Task Detail(HttpListenerRequest request, HttpListenerResponse response)
    {
        string? id = request.QueryString["id"];

        var data = service.GetProduct(id ?? "");

        var result = ApiResult.Success(data);

        await response.WriteJsonAsync(result);

    } 
}
