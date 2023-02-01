using _010;

var scheduler = new CustomTaskScheduler();
List<Task> tasks = new List<Task>();
Task task1 = new Task(() =>
{
    Write("Running 1 seconds");
    Thread.Sleep(1000);
});
tasks.Add(task1);
Task task2 = new Task(() =>
{
    Write("Running 2 seconds");
    Thread.Sleep(2000);
});
tasks.Add(task2);
foreach (var t in tasks)
{
    t.Start(scheduler);
}
Write("Press any key to quit..");
Console.ReadKey();

static void Write(string msg)
{
    Console.WriteLine($"{DateTime.Now:HH:mm:ss} on Thread { Thread.CurrentThread.ManagedThreadId} -- {msg}");
}
