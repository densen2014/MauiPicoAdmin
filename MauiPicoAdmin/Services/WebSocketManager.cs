using MauiPicoAdmin.Models;
using PicoServer;
using System.Text.Json;

namespace MauiPicoAdmin.Services;

public class WebSocketManager
{
    private WebAPIServer? api;

    public void RegisterWebSocket(WebAPIServer api)
    {
        this.api = api;
        api.enableWebSocket = true;
        api.WsOnConnectionChanged = WsConnectChanged;
        api.WsOnMessage = OnMessageReceived;

    }

    public async Task OnMessageReceived(string clientId, string message, Func<string, Task> reply)
    {
        await reply("收到！");
        var clients = api!.WsGetOnlineClients();
        foreach (var client in clients)
        {
            await api.WsSendToClientAsync(client, $"{clientId}说：{message}");
        }

        try
        {
            var cmd = JsonSerializer.Deserialize<WsCommand>(message, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (cmd != null)
            {
                switch (cmd.Type)
                {
                    case "device_control":
                        await Task.Delay(200);//模拟执行控制命令
                        //DeviceService.Execute(cmd.Device, cmd.Cmd);
                        await api.WsBroadcastAsync(JsonSerializer.Serialize(new
                        {
                            type = "device_status",
                            device = "printer",
                            status = cmd.Cmd == "start" ? "running" : "stop"
                        }));

                        break;
                }
            }
        }
        catch (JsonException)
        {
            // 处理 JSON 解析错误
        }
    }

    //相关方法
    //api.enableWebSocket = true; //启用WebSocket支持
    //api.WsOnConnectionChanged; // 事件：WebSocket客户端连接状态发生变化
    //api.WsOnMessage; //事件：收到WebSocket客户端发送来的消息
    //api.WsBroadcastAsync(); //对所有在线客户端广播消息
    //api.WsGetOnlineClients; //获取在线客户端列表
    //api.WsSendToClientAsync(client, message); //给指定客户端发送消息
    //api.WsEnableHeartbeat = true; //启用 WebSocket 服务端心跳检测，默认false
    //api.WsHeartbeatTimeout = 60; //设置 WebSocket 心跳时间，默认30秒
    //api.WsMaxConnections = 200; //设置 WebSocket 最大连接数，默认100
    //api.WsPingString = "hi"; //设置 WebSocket 的ping消息，默认"pong"，不区分大小写

    public async Task WsConnectChanged(string clientId, bool connected)
    {
        await api!.WsBroadcastAsync($"{clientId} {connected}");
    }

}
