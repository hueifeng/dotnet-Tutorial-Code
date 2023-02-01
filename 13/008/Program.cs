try
{
    var task = Task.Run(() => TaskMethod());
    task.Wait();
}
catch (AggregateException ae)
{
    foreach (var e in ae.InnerExceptions)
    {
        Console.WriteLine(e.Message);
    }
}
Console.ReadLine();

static Task TaskMethod()
{
    throw new Exception("This exception is expected!");
}
