Console.WriteLine("输入一行地址，按回车键进行下载");
while (true)
{
    var url = Console.ReadLine();
    Uri uri = new Uri(url);
    new Thread(() =>
    {
        Request(uri);
    }).Start();
}

static void Request(Uri uri)
{
    using HttpClient client = new HttpClient();
    HttpResponseMessage response;
    try
    {
        response = client.GetAsync(uri).Result;
        var content = response.Content.ReadAsByteArrayAsync().Result;
        if (content != null)
        {
            using var fileStream = File.Create($"./{DateTime.Now.ToString("yyyyMMdd-hhmmssff")}.html");
            fileStream.Write(content);
            fileStream.Flush();
        }
        Console.WriteLine($"{uri} 下载任务成功");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{uri} 下载任务失败，错误：{ex}");
    }
}
