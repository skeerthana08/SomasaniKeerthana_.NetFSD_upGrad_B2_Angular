using System;
using System.Threading.Tasks;

class Program
{
    static async Task VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying Payment...");
        await Task.Delay(2000);
        Console.WriteLine("Payment Verified");
    }

    static async Task CheckInventoryAsync()
    {
        Console.WriteLine("Checking Inventory...");
        await Task.Delay(2000);
        Console.WriteLine("Inventory Available");
    }

    static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Confirming Order...");
        await Task.Delay(2000);
        Console.WriteLine("Order Confirmed");
    }

    static async Task Main()
    {
        await VerifyPaymentAsync();
        await CheckInventoryAsync();
        await ConfirmOrderAsync();

        Console.WriteLine("Order Processing Completed");
    }
}