class Program
{
    private static readonly object _object = new object();

    public static void Print()
    {
        bool _lock = false;
        Monitor.Enter(_object, ref _lock);
        try
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }
        finally
        {
            if (_lock)
            {
                Monitor.Exit(_object);
            }
        }
    }

    static void Main()
    {
        Thread[] threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            threads[i] = new Thread(Print);
        }
        foreach (var t in threads)
        {
            t.Start();
        }
        Console.ReadLine();
    }
}
