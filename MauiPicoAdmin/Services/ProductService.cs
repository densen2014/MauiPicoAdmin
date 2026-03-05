namespace MauiPicoAdmin.Services;

public class ProductService
{
    public List<object> GetProducts()
    {
        return new List<object>
        {
            new { id = 1, name = "Apple", price = 10 },
            new { id = 2, name = "Orange", price = 8 }
        };
    }

    public object GetProduct(string id)
    {
        return new { id = id, name = "Demo Product", price = 100 };
    }
}
