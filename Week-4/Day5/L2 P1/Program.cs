using System;

// BankAccount class with encapsulation
class BankAccount
{
    // Private field
    private double balance;

    // Deposit method
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }
        else
        {
            Console.WriteLine("Invalid deposit amount!");
        }
    }

    // Withdraw method
    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance!");
        }
        else if (amount > 0)
        {
            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount!");
        }
    }

    // Method to get balance
    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Console.Write("Enter amount to deposit: ");
        double deposit = double.Parse(Console.ReadLine());

        account.Deposit(deposit);

        Console.Write("Enter amount to withdraw: ");
        double withdraw = double.Parse(Console.ReadLine());

        account.Withdraw(withdraw);

        Console.WriteLine("\nCurrent Balance = " + account.GetBalance());
    }
}