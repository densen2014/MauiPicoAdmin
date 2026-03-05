using System;
using System.Collections.Generic;
using System.Text;

namespace MauiPicoAdmin.Models;

public class ApiResult
{
    public int Code { get; set; }
    public string? Message { get; set; }
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

