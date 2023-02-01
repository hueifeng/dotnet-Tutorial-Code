using _016;
using System.Diagnostics;

DiagnosticListener.AllListeners.Subscribe(new MyObserver());
var diagnosticSource = new DiagnosticListener("App.Log");
var name = "App.Log";

if (diagnosticSource.IsEnabled(name))
{
    diagnosticSource.Write(name, new { Name = "Mr.A", Age = "18" });
}
Console.ReadLine();