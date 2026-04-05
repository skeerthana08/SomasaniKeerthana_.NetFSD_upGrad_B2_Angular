using System;
using Microsoft.Extensions.Configuration;
using ProductApp.Data;
using ProductApp.Models;
using System.IO;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        ProductDataAccess db = new ProductDataAccess(config);

        while (true)
        {
            Console.WriteLine("\n1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Product p = new Product();

                    Console.Write("Name: ");
                    p.ProductName = Console.ReadLine();

                    Console.Write("Category: ");
                    p.Category = Console.ReadLine();

                    Console.Write("Price: ");
                    p.Price = decimal.Parse(Console.ReadLine());

                    db.InsertProduct(p);
                    Console.WriteLine("Inserted!");
                    break;

                case 2:
                    var products = db.GetAllProducts();
                    foreach (var item in products)
                    {
                        Console.WriteLine($"{item.ProductId} | {item.ProductName} | {item.Category} | {item.Price}");
                    }
                    break;

                case 3:
                    Product up = new Product();

                    Console.Write("Enter ID: ");
                    up.ProductId = int.Parse(Console.ReadLine());

                    Console.Write("New Name: ");
                    up.ProductName = Console.ReadLine();

                    Console.Write("New Category: ");
                    up.Category = Console.ReadLine();

                    Console.Write("New Price: ");
                    up.Price = decimal.Parse(Console.ReadLine());

                    db.UpdateProduct(up);
                    Console.WriteLine("Updated!");
                    break;

                case 4:
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());

                    db.DeleteProduct(id);
                    Console.WriteLine("Deleted!");
                    break;

                case 5:
                    return;
            }
        }
    }
}