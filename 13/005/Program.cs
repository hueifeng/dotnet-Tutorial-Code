var cts = new CancellationTokenSource();
var task = new Task<int>(() => TaskMethod(10, cts.Token), cts.Token);
Console.WriteLine(task.Status);
cts.Cancel();
Console.WriteLine(task.Status);

static int TaskMethod(int count, CancellationToken token)
{
    for (int i = 0; i < count; i++)
    {
        Thread.Sleep(1000);
        if (token.IsCancellationRequested) return -1;
    }
    return count;
}
Console.ReadLine();