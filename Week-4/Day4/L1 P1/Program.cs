using System;

// Create Calculator class
class Calculator
{
    // Method for addition
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Method for subtraction
    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter First Number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        int num2 = int.Parse(Console.ReadLine());

        // Create object
        Calculator calc = new Calculator();

        // Call methods
        int addition = calc.Add(num1, num2);
        int subtraction = calc.Subtract(num1, num2);

        // Display output
        Console.WriteLine("\nAddition = " + addition);
        Console.WriteLine("Subtraction = " + subtraction);
    }
}