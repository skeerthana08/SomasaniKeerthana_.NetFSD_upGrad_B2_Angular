using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Number: ");
        int n = int.Parse(Console.ReadLine());

        int evenCount = 0;
        int oddCount = 0;
        int sum = 0;

        // Loop from 1 to N
        for (int i = 1; i <= n; i++)
        {
            sum += i;

            if (i % 2 == 0)
                evenCount++;
            else
                oddCount++;
        }

        Console.WriteLine("\nEven Count: " + evenCount);
        Console.WriteLine("Odd Count: " + oddCount);
        Console.WriteLine("Sum: " + sum);
    }
}