namespace MauiPicoAdmin;

[AttributeUsage(AttributeTargets.Method)]
public class ApiRouteAttribute : Attribute
{
    public string Path { get; }
    public string? Method { get; } 

    public ApiRouteAttribute(string path)
    {
        Path = path;
    }

    public ApiRouteAttribute(string path, string? method)
    {
        Path = path;
        Method = method;
    }
}