using System.Diagnostics;

namespace _016
{
    public class MyObserver : IObserver<DiagnosticListener>,
    IObserver<KeyValuePair<string, object?>>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(KeyValuePair<string, object?> value)
        {
            Console.WriteLine($"{value.Key}:{value.Value}");
        }

        public void OnNext(DiagnosticListener value)
        {
            if (value.Name == "App.Log")
            {
                value.Subscribe(this);
            }
        }
    }

}
