var cts = new CancellationTokenSource();
var task = new Task<int>(() => TaskMethod(10, cts.Token), cts.Token);
Console.WriteLine(task.Status);
task.Start();
for (int i = 0; i < 10; i++)
{
    Thread.Sleep(100);
    Console.WriteLine(task.Status);
}
cts.Cancel();
for (int i = 0; i < 10; i++)
{
    Thread.Sleep(100);
    Console.WriteLine(task.Status);
}
Console.WriteLine(task.Result);
Console.ReadLine();

static int TaskMethod(int count, CancellationToken token)
{
    for (int i = 0; i < count; i++)
    {
        Thread.Sleep(1000);
        if (token.IsCancellationRequested) return -1;
    }
    return count;
}
