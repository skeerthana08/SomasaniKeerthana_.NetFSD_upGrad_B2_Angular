using System;

// Create Student class
class Student
{
    // Method to calculate average
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }

    // Method to get grade based on average
    public char GetGrade(double avg)
    {
        if (avg >= 90)
            return 'A';
        else if (avg >= 75)
            return 'B';
        else if (avg >= 60)
            return 'C';
        else if (avg >= 50)
            return 'D';
        else
            return 'F';
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter marks 1: ");
        int m1 = int.Parse(Console.ReadLine());

        Console.Write("Enter marks 2: ");
        int m2 = int.Parse(Console.ReadLine());

        Console.Write("Enter marks 3: ");
        int m3 = int.Parse(Console.ReadLine());

        // Create object
        Student student = new Student();

        // Calculate average
        double avg = student.CalculateAverage(m1, m2, m3);

        // Get grade
        char grade = student.GetGrade(avg);

        // Display result
        Console.WriteLine("\nAverage = " + avg);
        Console.WriteLine("Grade = " + grade);
    }
}