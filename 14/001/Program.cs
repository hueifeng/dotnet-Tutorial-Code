class Program
{
    static int value = 0;
    static void Main(string[] args)
    {
        Parallel.For(0, 10000,
            _ =>
            {
                value += 1;
            });
        Console.WriteLine(value);
    }
}
