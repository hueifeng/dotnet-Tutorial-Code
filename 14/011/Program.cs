class Program
{
    private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 2);
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            Thread thread = new Thread(Print);
            thread.Name = "Thread:" + i;
            thread.Start();
        }
    }

    private static void Print()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} 即将开始进行等待处理");
        try
        {
            _semaphore.Wait();
            Console.WriteLine($"开始: {Thread.CurrentThread.Name} 处理中...");
            Thread.Sleep(5000);
            Console.WriteLine(Thread.CurrentThread.Name + " 退出.");
        }
        finally
        {
            _semaphore.Release();
            Console.WriteLine("Semaphore Release");
        }
    }
}
