using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var provider = new ServiceCollection()
            .AddSingleton<MessagePrinter>()
            .AddSingleton<IWriter, MessageWriter>()
            .BuildServiceProvider();
        var messageWriter = provider.GetService<MessagePrinter>();
        messageWriter.Print();
    }
}


/// <summary>
/// 打印类
/// </summary>
public class MessagePrinter
{
    private IWriter _writer;
    /// <summary>
    /// 构造函数注入，由依赖注入框架管理对象的创建过程，开发者无需使用new进行创建
    /// </summary>
    /// <param name="writer"></param>
    public MessagePrinter(IWriter writer)
    {
        //writer = new MessageWriter(); 
        _writer = writer;
    }
    public void Print()
    {
        _writer.Write("Hello World");
    }
}
/// <summary>
/// 消息输出
/// </summary>
public class MessageWriter : IWriter
{
    public void Write(string msg)
    {
        Console.Out.WriteLine(msg);
    }
}

public interface IWriter
{
    void Write(string msg);
}
