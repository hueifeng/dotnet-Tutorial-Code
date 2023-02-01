namespace _003
{
    public class Sample : ISampleSingleton, ISampleScoped, ISampleTransient
    {
        private static int _counter;
        private int _id;
        public Sample()
        {
            _id = ++_counter;
        }
        public int Id => _id;
    }
}
