var cts = new CancellationTokenSource();
Parallel.ForEach(Enumerable.Range(1, 10), new ParallelOptions
{
    CancellationToken = cts.Token,
    MaxDegreeOfParallelism = Environment.ProcessorCount,
    TaskScheduler = TaskScheduler.Default
}, (i, state) =>
{
    Process(i);
});
Console.WriteLine("Done");
Console.ReadLine();

static void Process(int i)
{
    Console.WriteLine($"Id：{i}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
}
