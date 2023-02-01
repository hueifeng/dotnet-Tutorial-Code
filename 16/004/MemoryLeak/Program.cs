using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to exit...");
        while (!Console.KeyAvailable)
        {
            var array = new double[100000000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            System.Threading.Thread.Sleep(10);
        }
        Console.WriteLine("Done");
    }
}
