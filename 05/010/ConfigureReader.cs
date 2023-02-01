using _009;
using Microsoft.Extensions.Options;

namespace _010
{
    public class ConfigureReader
    {
        private readonly Person _person;
        public ConfigureReader(IOptionsSnapshot<Person> optionsSnapshot)
        {
            _person = optionsSnapshot.Value;
        }
        public int GetAge()
        {
            return _person.Age;
        }
    }
}

