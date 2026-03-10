using PicoServer;
using System.Net;
using System.Text.Json;

namespace MauiPicoAdmin;

public static class HttpHelper
{
    public static async Task WriteJsonAsync(this HttpListenerResponse response, object obj)
    {
        string json = JsonSerializer.Serialize(obj);
        await response.WriteAsync(json, contentType: "application/json");
    }

    public static async Task Notify(HttpListenerRequest request, HttpListenerResponse response)
    {
        response.ContentType = "text/event-stream";
        response.Headers.Add("Cache-Control", "no-cache");
        response.SendChunked = true;

        try
        {
            for (int i = 0; i < 5; i++)
            {
                string msg = $"data: 消息推送 {i} 时间: {DateTime.Now}\n\n";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(msg);
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                await response.OutputStream.FlushAsync();
                await Task.Delay(1000);
            }
        }
        finally
        {
            //在使用 HttpListenerResponse 进行 SSE（Server - Sent Events）推送时，response.Close(); 并不是必须的，但推荐在推送结束后调用它，以确保资源释放和连接正确关闭。

            // 示例这里是推送结束后调用 response.Close();，确保响应流关闭
            // 如果是无限推送（如实时设备报警），不要关闭响应，直到客户端断开。
            response.Close();
        }
    }
}

