class Program
{
    static long _value;
    static void Main()
    {
        Thread thread1 = new Thread(new ThreadStart(DoWork));
        thread1.Start();
        thread1.Join();
        Console.WriteLine(Interlocked.Read(ref _value));
    }

    static void DoWork()
    {
        Interlocked.Exchange(ref _value, 10);
        long result = Interlocked.CompareExchange(ref _value, 30, 10);
        Console.WriteLine(result);
    }
}
