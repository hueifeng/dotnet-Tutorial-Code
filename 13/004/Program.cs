Task<int> task = Task.Run(() =>
{
    return new Random().Next();
});
Console.WriteLine(task.Result);
Console.ReadLine();
OperationCanceledException operationCanceledException = new OperationCanceledException();
operationCanceledException.CancellationToken