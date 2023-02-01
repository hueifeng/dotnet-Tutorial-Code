class Program
{
    private static Semaphore _semaphore = new Semaphore(5, 5, "Semaphore");
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
            _semaphore.WaitOne();
            Console.WriteLine($"开始: {Thread.CurrentThread.Name} 处理中...");
        }
        finally
        {
            Console.ReadLine();
            _semaphore.Release();
        }
    }
}
