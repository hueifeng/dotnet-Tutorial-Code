class Program
{
    static void Main(string[] args)
    {
        MessagePrinter messagePrinter = new MessagePrinter();//
        messagePrinter.Print();
    }
}
/// <summary>
/// 打印类
/// </summary>
public class MessagePrinter
{
    private MessageWriter writer;
    public MessagePrinter()
    {
        writer = new MessageWriter();
    }
    public void Print()
    {
        writer.Write("Hello World");
    }
}

/// <summary>
/// 消息输出
/// </summary>
public class MessageWriter
{
    public void Write(string msg)
    {
        Console.Out.WriteLine(msg);
    }
}
