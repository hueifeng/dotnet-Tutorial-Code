class Program
{
    static void Main()
    {
        var spinLock = new SpinLock();
        var list = new List<int>();
        Parallel.For(0, 10000000, r =>
        {
            bool lockTaken = false;//释放成功
            try
            {
                spinLock.Enter(ref lockTaken);//进入锁
                list.Add(r);
            }
            finally
            {
                if (lockTaken) spinLock.Exit(false); //释放
            }
        });
        Console.WriteLine(list.Count);
        //输出：10000000
    }
}
