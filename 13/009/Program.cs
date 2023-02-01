Task<DateTime> taskA = Task.Run(() => DateTime.Now);
await taskA.ContinueWith(antecedent
        => Console.WriteLine(
                    $"Today is {antecedent.Result.DayOfWeek}."));

Console.ReadLine();