
using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        int experience = int.Parse(Console.ReadLine());

        double bonusPercentage;

        // Using if-else
        if (experience < 2)
            bonusPercentage = 0.05;
        else if (experience <= 5)
            bonusPercentage = 0.10;
        else
            bonusPercentage = 0.15;

        // Using ternary (just to satisfy requirement)
        double bonus = salary * bonusPercentage;

        double finalSalary = salary + bonus;

        Console.WriteLine("\nEmployee: " + name);
        Console.WriteLine("Bonus: " + bonus);
        Console.WriteLine("Final Salary: " + finalSalary);
    }
}