using Microsoft.Extensions.Options;

namespace _009
{
    public class CountIncrement : IConfigureOptions<Person>
    {
        static int SetupInvokeCount { get; set; }

        public void Configure(Person options)
        {
            SetupInvokeCount++;
            options.Age += SetupInvokeCount;
        }
    }

}
