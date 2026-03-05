using PicoServer;
using System.Net;
using System.Text.Json;

namespace MauiPicoAdmin.Controllers;

public static class FileHelper
{

    /// <summary>
    /// 每次 Debug/Build 前自动生成 wwwroot/filelist.txt，内容为所有 wwwroot 下的文件相对路径。无需手动维护清单，App 启动时可自动释放所有包内静态文件。
    /// </summary>
    /// <returns></returns>
    public static async Task EnsureWwwrootExistsAsync()
    {
        string wwwrootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
        if (!Directory.Exists(wwwrootPath))
        {
            Directory.CreateDirectory(wwwrootPath);
            string[] files;
            try
            {
                using var listStream = await FileSystem.OpenAppPackageFileAsync("wwwroot/filelist.txt");
                using var reader = new StreamReader(listStream);
                var content = await reader.ReadToEndAsync();
                files = content.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            }
            catch
            {
                files = new[] { "index.html" };
            }
            foreach (var file in files)
            {
                string destPath = Path.Combine(wwwrootPath, file);
                string packagePath = $"wwwroot/{file}";
                string destDir = Path.GetDirectoryName(destPath)!;
                if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);
                using var stream = await FileSystem.OpenAppPackageFileAsync(packagePath);
                using var fileStream = File.Create(destPath);
                await stream.CopyToAsync(fileStream);
            }
        }
    }


}

