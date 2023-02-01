class Program
{
    static void Main(string[] args)
    {
        var thread = new Thread(DoWork);
        thread.Start();
        Thread.Sleep(50);
        _isCompleted = true;
        Console.ReadKey();
    }

    private static volatile bool _isCompleted = false;

    static void DoWork()
    {
        SpinWait spinWait = new SpinWait();
        while (!_isCompleted)
        {
            spinWait.SpinOnce();
            Console.WriteLine($"自旋次数：{spinWait.Count}，下次调用触发上下文切换和内核转换：{spinWait.NextSpinWillYield}");
        }
        Console.WriteLine("Waiting is complete");
    }
}
