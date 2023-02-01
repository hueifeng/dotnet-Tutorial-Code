namespace _004
{
    public class Sample : ISampleSingleton, ISampleScoped, ISampleTransient
    {
        private static int _counter;
        private int _id;

        public Sample(ISample sample)
        {
            _id = ++_counter;
        }
        public int Id => _id;
    }

}
