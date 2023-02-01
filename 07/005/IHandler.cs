namespace _004
{
    public interface IHandler
    {
        void Process(string msg);
    }
    public abstract class Processor : IHandler
    {
        private IHandler _next;

        public Processor Next(IHandler next)
        {
            this._next = next;
            return this;
        }

        public void Process(string msg)
        {
            DoProcess(msg);
            if (_next != null)
            {
                _next.Process(msg);
            }
        }
        public abstract void DoProcess(string msg);
    }
}
