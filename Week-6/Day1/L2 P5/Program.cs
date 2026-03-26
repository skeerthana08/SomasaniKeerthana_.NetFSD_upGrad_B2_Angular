using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
        Trace.AutoFlush = true;

        Trace.WriteLine("Order Validation Started");
        Trace.TraceInformation("Order Validated");

        Trace.WriteLine("Payment Processing Started");
        Trace.TraceInformation("Payment Successful");

        Trace.WriteLine("Inventory Update Started");
        Trace.TraceInformation("Inventory Updated");

        Trace.WriteLine("Invoice Generation Started");
        Trace.TraceInformation("Invoice Generated");

        Console.WriteLine("Order processed. Check log.txt file.");
    }
}