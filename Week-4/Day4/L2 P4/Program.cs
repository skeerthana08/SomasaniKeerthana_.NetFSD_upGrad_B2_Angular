using System;

class OrderCalculator
{
    // Method with optional parameters
    public double CalculateFinalAmount(double price, int quantity, double discount = 0, double shipping = 50)
    {
        double subtotal = price * quantity;

        double discountAmount = subtotal * (discount / 100);
        double afterDiscount = subtotal - discountAmount;

        double finalAmount = afterDiscount + shipping;

        Console.WriteLine("\nSubtotal: " + subtotal);
        Console.WriteLine("Discount: " + discountAmount);
        Console.WriteLine("Shipping: " + shipping);

        return finalAmount;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter product price: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        OrderCalculator calc = new OrderCalculator();

        // Call with default discount & shipping
        double final1 = calc.CalculateFinalAmount(price, quantity);
        Console.WriteLine("Final Amount (default): " + final1);

        // Call with discount only
        double final2 = calc.CalculateFinalAmount(price, quantity, 10);
        Console.WriteLine("Final Amount (10% discount): " + final2);

        // Call with discount + custom shipping
        double final3 = calc.CalculateFinalAmount(price, quantity, 10, 100);
        Console.WriteLine("Final Amount (10% + shipping 100): " + final3);
    }
}