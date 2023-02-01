using System.Runtime.InteropServices;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"系统架构：{RuntimeInformation.OSArchitecture}");
        Console.WriteLine($"系统名称：{RuntimeInformation.OSDescription}");
        Console.WriteLine($"进程架构：{RuntimeInformation.ProcessArchitecture}");
        Console.WriteLine($"是否64位操作系统：{Environment.Is64BitOperatingSystem}");
        Console.Read();
    }
}