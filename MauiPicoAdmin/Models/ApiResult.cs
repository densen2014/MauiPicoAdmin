using System.Text.Json.Serialization;

namespace MauiPicoAdmin.Models;

public class ApiResult
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("data")]
    public object? Data { get; set; }

    public static ApiResult Success(object data)
    {
        return new ApiResult
        {
            Code = 0,
            Message = "ok",
            Data = data
        };
    }

    public static ApiResult Error(string msg)
    {
        return new ApiResult
        {
            Code = 1,
            Message = msg
        };
    }
}

