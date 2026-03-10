namespace MauiPicoAdmin;

[AttributeUsage(AttributeTargets.Method)]
public class RequireAttribute : Attribute
{
    public string Permission { get; }

    public RequireAttribute(string permission)
    {
        Permission = permission;
    }
}
 