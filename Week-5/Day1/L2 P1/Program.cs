using System;

// Base class
class Product
{
    private double price;

    public string Name { get; set; }

    // Property with validation (Encapsulation)
    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("Invalid price!");
        }
    }

    // Virtual method
    public virtual double CalculateDiscount()
    {
        return 0;
    }

    public double GetFinalPrice()
    {
        return Price - CalculateDiscount();
    }
}

// Derived class: Electronics
class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price * 0.05; // 5% discount
    }
}

// Derived class: Clothing
class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price * 0.15; // 15% discount
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Electronics Price: ");
        double ePrice = double.Parse(Console.ReadLine());

        Console.Write("Enter Clothing Price: ");
        double cPrice = double.Parse(Console.ReadLine());

        // Polymorphism
        Product p1 = new Electronics { Name = "Electronics", Price = ePrice };
        Product p2 = new Clothing { Name = "Clothing", Price = cPrice };

        Console.WriteLine("\nElectronics Final Price: " + p1.GetFinalPrice());
        Console.WriteLine("Clothing Final Price: " + p2.GetFinalPrice());
    }
}