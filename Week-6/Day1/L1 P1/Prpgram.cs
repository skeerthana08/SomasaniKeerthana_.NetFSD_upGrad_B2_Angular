using System;
using System.Threading.Tasks;

class Program
{
    static async Task WriteLogAsync(string message)
    {
        Console.WriteLine($"Start Writing: {message}");
        await Task.Delay(2000); // simulate file writing
        Console.WriteLine($"Completed Writing: {message}");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Logging started...");

        Task t1 = WriteLogAsync("Log 1");
        Task t2 = WriteLogAsync("Log 2");
        Task t3 = WriteLogAsync("Log 3");

        await Task.WhenAll(t1, t2, t3);

        Console.WriteLine("All logs written.");
    }
}