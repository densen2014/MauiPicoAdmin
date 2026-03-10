using MauiPicoAdmin.Models;
using System.Net;

namespace MauiPicoAdmin.Controllers;

[ApiController]
public class ProductController
{
    private ProductService service = new ProductService();

    [ApiRoute("/api/product/list")]
    public async Task List(HttpListenerRequest request, HttpListenerResponse response)
    {
        var data = service.GetProducts();

        var result = ApiResult.Success(data);

        await response.WriteJsonAsync(result);
    }

    [ApiRoute("/api/product/detail")]
    public async Task Detail(HttpListenerRequest request, HttpListenerResponse response)
    {
        string? id = request.QueryString["id"];

        var data = service.GetProduct(id ?? "");

        var result = ApiResult.Success(data);

        await response.WriteJsonAsync(result);

    } 
}
