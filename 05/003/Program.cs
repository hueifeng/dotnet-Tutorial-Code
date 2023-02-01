using Microsoft.Extensions.Configuration;

var key = "ConnectionStrings:DefaultConnection";
//创建ConfigurationManager实例对象
ConfigurationManager configurationManager = new ConfigurationManager();
//通过指定的Key读取配置
Console.WriteLine($"第一次输出：{configurationManager[key]}");

//调用AddJsonFile扩展方法，添加config.json配置文件
configurationManager.AddJsonFile("config.json", true, true);
Console.WriteLine($"第二次输出：{configurationManager[key]}");
Console.ReadKey();
