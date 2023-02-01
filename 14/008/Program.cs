class Program
{
    private static Mutex mutex = new Mutex(false);
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(Print);
            thread.Name = "Thread:" + i;
            thread.Start();
        }
        Console.ReadKey();
    }

    static void Print()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} 即将开始进行等待处理");
        try
        {
            //阻塞当前线程，直到WaitOne方法接收到信号
            mutex.WaitOne();
            Console.WriteLine($"开始: {Thread.CurrentThread.Name} 处理中...");
            Thread.Sleep(2000);
            Console.WriteLine($"完成: {Thread.CurrentThread.Name}");
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
}
