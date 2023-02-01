class Program
{
    static void Main()
    {
        var location = 1;
        var value = 3;
        var compared = 1;
        Interlocked.CompareExchange(ref location, value, compared);
        Console.WriteLine(location);
    }
}
