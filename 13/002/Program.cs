for (int i = 0; i < 20; i++)
{
    ThreadPool.QueueUserWorkItem(state => DoWork());
}
Console.Read();

static void DoWork()
{
    Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId},ThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread},Background: {Thread.CurrentThread.IsBackground}");
}

