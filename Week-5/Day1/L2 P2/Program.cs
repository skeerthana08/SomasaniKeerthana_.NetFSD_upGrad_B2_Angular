using System;

// Base class
class Vehicle
{
    public string Brand { get; set; }
    public double RentalRatePerDay { get; set; }

    // Virtual method
    public virtual double CalculateRental(int days)
    {
        return RentalRatePerDay * days;
    }
}

// Derived class: Car
class Car : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total + 500; // insurance charge
    }
}

// Derived class: Bike
class Bike : Vehicle
{
    public override double CalculateRental(int days)
    {
        double total = base.CalculateRental(days);
        return total - (total * 0.05); // 5% discount
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter rental rate per day: ");
        double rate = double.Parse(Console.ReadLine());

        Console.Write("Enter number of days: ");
        int days = int.Parse(Console.ReadLine());

        if (days <= 0)
        {
            Console.WriteLine("Invalid number of days!");
            return;
        }

        // Polymorphism
        Vehicle car = new Car { Brand = "Car", RentalRatePerDay = rate };
        Vehicle bike = new Bike { Brand = "Bike", RentalRatePerDay = rate };

        Console.WriteLine("\nCar Rental = " + car.CalculateRental(days));
        Console.WriteLine("Bike Rental = " + bike.CalculateRental(days));
    }
}