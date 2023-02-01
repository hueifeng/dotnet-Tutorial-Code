using _001;
using BenchmarkDotNet.Running;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Md5VsSha256>();
        Console.ReadLine();
    }
}
