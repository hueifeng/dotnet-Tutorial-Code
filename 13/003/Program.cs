Task task = Task.Run(() =>
{
    Console.WriteLine("任务");
});

Console.WriteLine("主线程执行");
task.Wait();
Console.ReadLine();