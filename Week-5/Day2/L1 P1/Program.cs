using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Input marks
        int[] marks = { 78, 85, 90, 67, 88 };

        Console.Write("Enter threshold: ");
        int threshold = int.Parse(Console.ReadLine());

        // Total using Sum (like reduce)
        int total = marks.Sum();

        // Average
        double average = marks.Average();

        // Count above threshold (like filter)
        int countAbove = marks.Count(m => m > threshold);

        // Highest score
        int highest = marks.Max();

        // Dictionary (Map concept)
        Dictionary<string, int> subjectHighest = new Dictionary<string, int>()
        {
            { "Math", 90 },
            { "Science", 88 },
            { "English", 85 }
        };

        // Output
        Console.WriteLine("\nTotal Marks: " + total);
        Console.WriteLine("Average Marks: " + average);
        Console.WriteLine("Students above " + threshold + ": " + countAbove);
        Console.WriteLine("Highest Score: " + highest);

        Console.WriteLine("\nSubject-wise Highest:");
        foreach (var item in subjectHighest)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}