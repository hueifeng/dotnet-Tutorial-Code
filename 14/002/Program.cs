class Program
{
    static int value = 0;
    static void Main(string[] args)
    {
        Parallel.For(0, 10000, _ =>
        {
            Interlocked.Add(ref value, 1);
        });
        Console.WriteLine(value);
    }
}
