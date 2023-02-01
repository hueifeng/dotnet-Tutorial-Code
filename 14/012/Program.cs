class Program {

    private static ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
    private static List<int> items = new List<int>();
    private static void Reader()
    {
        Console.WriteLine("读取内容");
        while (true)
        {
            try
            {
                readerWriterLock.EnterReadLock();
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }
    }

    private static void Writer()
    {
        while (true)
        {
            try
            {
                int number = new Random().Next(20);
                readerWriterLock.EnterWriteLock();
                items.Add(number);
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} added {number}");
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }
    }

    static void Main(string[] args)
    {
        Thread[] threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            threads[i] = new Thread(Reader);
        }
        foreach (var t in threads)
        {
            t.Start();
        }

        var wThread1 = new Thread(Writer);
        wThread1.Start();
        var wThread2 = new Thread(Writer);
        wThread2.Start();

        Console.ReadKey();
    }
}
