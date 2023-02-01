using _004;

IHandler handler1 = new Handler1();
IHandler handler2 = new Handler2().Next(handler1);
IHandler handler3 = new Handler3().Next(handler2);
handler3.Process("hello");
public class Handler1 : Processor
{
    public override void DoProcess(string msg)
    {
        Console.WriteLine($"{nameof(Handler1)}：{msg}");
    }
}

public class Handler2 : Processor
{
    public override void DoProcess(string msg)
    {
        Console.WriteLine($"{nameof(Handler2)}：{msg}");
    }
}
public class Handler3 : Processor
{
    public override void DoProcess(string msg)
    {
        Console.WriteLine($"{nameof(Handler3)}：{msg}");
    }
}