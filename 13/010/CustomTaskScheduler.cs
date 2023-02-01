using System.Collections.Concurrent;

namespace _010
{
    public class CustomTaskScheduler : TaskScheduler, IDisposable
    {
        private BlockingCollection<Task> _tasks = new BlockingCollection<Task>();
        private readonly Thread _mainThread;
        public CustomTaskScheduler()
        {
            _mainThread = new Thread(this.Execute);
        }
        private void Execute()
        {
            Console.WriteLine($"Starting Thread {Thread.CurrentThread.ManagedThreadId}");
            foreach (var t in _tasks.GetConsumingEnumerable())
            {
                TryExecuteTask(t);
            }
        }
        protected override IEnumerable<Task>? GetScheduledTasks()
        {
            return _tasks.ToArray<Task>();
        }
        protected override void QueueTask(Task task)
        {
            _tasks.Add(task);
            if (!_mainThread.IsAlive)
            {
                _mainThread.Start();
            }
        }
        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
        public void Dispose()
        {
            _tasks.CompleteAdding();
        }
    }
}
