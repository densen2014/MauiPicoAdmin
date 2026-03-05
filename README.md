# NET MAUI 嵌入式 Web 架构实战 

[https://github.com/densen2014/MauiPicoAdmin](https://www.cnblogs.com/densen2014/p/19670893)

| 文章   | 内容                    |
| ---- | --------------------- |
| 第1篇  | 在 MAUI 应用中运行 PicoServer 构建本地 HTTP API 服务          |
| 第2篇  | 路由机制与 API 设计          |
| 第3篇  | 构建可扩展 REST API 框架     |
| 第4篇  | 静态文件托管与前端整合           |
| 第5篇  | 构建 Web Admin 管理后台     |
| 第6篇  | 登录认证与权限系统             |
| 第7篇  | 局域网访问与设备管理            |
| 第8篇  | 本地数据与缓存架构             |
| 第9篇  | PicoServer + PWA 离线系统 |
| 第10篇 | 完整 App Web Shell 架构   |

   

## MAUI + PicoServer 架构图

```
        Browser
           │
        HTTP API
           │
      PicoServer
           │
    ┌──────┴──────┐
    │             │
 Web Admin     REST API
    │             │
      MAUI App Core
           │
        Device
```

关键词：
.NET MAUI
PicoServer
MAUI Web Server
MAUI HTTP API
嵌入式 Web Server
MAUI Web Admin
