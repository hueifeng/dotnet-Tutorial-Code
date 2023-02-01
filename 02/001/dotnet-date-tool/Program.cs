using System.CommandLine;
using System.CommandLine.IO;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var cmd = new RootCommand
            {
                new Option<string>("--name", "请输入执行者名称"),
                new Option<string>("--format", "获取指定格式的时间字符串")
                {
                    IsRequired = true
                }
            };
        cmd.Name = "dotnet-date-tool";
        cmd.Description = "日期获取工具";
        cmd.SetHandler<string, string, IConsole>(HandleCmd, cmd.Options[0], cmd.Options[1]);

        return await cmd.InvokeAsync(args);
    }

    static void HandleCmd(string name, string format, IConsole console)
    {
        if (!string.IsNullOrWhiteSpace(format))
        {
            var date = DateTime.Now.ToString(format);
            if (!string.IsNullOrWhiteSpace(name))
            {
                console.Out.WriteLine($"你好，{name}，日期根据指定格式转换后为{date}");
                return;
            }
            console.Out.WriteLine(date);
        }
    }
}
