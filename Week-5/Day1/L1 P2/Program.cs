using System;

// Base class
class Employee
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    // Virtual method
    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

// Derived class: Manager
class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20); // 20% bonus
    }
}

// Derived class: Developer
class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10); // 10% bonus
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Base Salary: ");
        double baseSalary = double.Parse(Console.ReadLine());

        // Polymorphism using base reference
        Employee manager = new Manager { Name = "Manager", BaseSalary = baseSalary };
        Employee developer = new Developer { Name = "Developer", BaseSalary = baseSalary };

        Console.WriteLine("\nManager Salary = " + manager.CalculateSalary());
        Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
    }
}