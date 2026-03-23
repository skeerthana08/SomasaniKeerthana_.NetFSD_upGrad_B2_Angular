using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Marks: ");
        int marks = int.Parse(Console.ReadLine());

        if (marks < 0 || marks > 100)
        {
            Console.WriteLine("Invalid marks! Please enter between 0 and 100.");
        }
        else
        {
            char grade;

            if (marks >= 90)
                grade = 'A';
            else if (marks >= 75)
                grade = 'B';
            else if (marks >= 60)
                grade = 'C';
            else if (marks >= 50)
                grade = 'D';
            else
                grade = 'F';

            Console.WriteLine("Student: " + name);
            Console.WriteLine("Grade: " + grade);
        }
    }
}
