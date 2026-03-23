using System;

class BankAccount
{
    // Private fields
    private int accountNumber;
    private double balance;

    // Property for Account Number
    public int AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    // Property for Balance (read-only outside)
    public double Balance
    {
        get { return balance; }
    }

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
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount!");
        }
        else if (amount > balance)
        {
            Console.WriteLine("Insufficient balance!");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        Console.Write("Enter Account Number: ");
        acc.AccountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter deposit amount: ");
        double deposit = double.Parse(Console.ReadLine());
        acc.Deposit(deposit);

        Console.Write("Enter withdrawal amount: ");
        double withdraw = double.Parse(Console.ReadLine());
        acc.Withdraw(withdraw);

        Console.WriteLine("\nCurrent Balance = " + acc.Balance);
    }
}