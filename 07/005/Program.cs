using _004;

List<IHandler> handlers = new List<IHandler>();
handlers.Add(new Handler1());
handlers.Add(new Handler2());
handlers.Add(new Handler3());
foreach (var handler in handlers)
{
    handler.Process("hello");
}

public class Handler1 : IHandler
{
    public void Process(string msg)
    {
        Console.WriteLine($"{nameof(Handler1)}：{msg}");
    }
}
public class Handler2 : IHandler
{
    public void Process(string msg)
    {
        Console.WriteLine($"{nameof(Handler2)}：{msg}");
    }
}
public class Handler3 : IHandler
{
    public void Process(string msg)
    {
        Console.WriteLine($"{nameof(Handler3)}：{msg}");
    }
}

