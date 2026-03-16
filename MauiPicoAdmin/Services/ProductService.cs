namespace MauiPicoAdmin.Services;

public class ProductService
{
    public List<object> GetProducts()
    {
        return new List<object>
        {
            new { id = 1, name = "Apple", price = 10 },
            new { id = 2, name = "Orange", price = 8 },
            new { id = 3, name = "Banana", price = 5 },
            new { id = 4, name = "Grape", price = 12 },
            new { id = 5, name = "Watermelon", price = 20 },
            new { id = 6, name = "Pineapple", price = 15 },
            new { id = 7, name = "Mango", price = 18 },
            new { id = 8, name = "Strawberry", price = 25 },
            new { id = 9, name = "Blueberry", price = 30 },
            new { id = 10, name = "Peach", price = 14 },
            new { id = 11, name = "Pear", price = 9 },
            new { id = 12, name = "Plum", price = 11 },
            new { id = 13, name = "Kiwi", price = 13 },
            new { id = 14, name = "Lemon", price = 7 },
            new { id = 15, name = "Cherry", price = 28 },
            new { id = 16, name = "Coconut", price = 22 },
            new { id = 17, name = "Papaya", price = 16 },
            new { id = 18, name = "Lychee", price = 19 },
            new { id = 19, name = "Fig", price = 17 },
            new { id = 20, name = "Pomegranate", price = 26 },
            new { id = 21, name = "Guava", price = 21 },
            new { id = 22, name = "Apricot", price = 23 },
            new { id = 23, name = "Dragonfruit", price = 35 }
        };
    }

    public object? GetProduct(string idOrName)
    {
        return GetProducts().FirstOrDefault(a =>
            a.GetType().GetProperty("id")?.GetValue(a)?.ToString() == idOrName ||
            a.GetType().GetProperty("name")?.GetValue(a)?.ToString() == idOrName
        );
    } 
}
