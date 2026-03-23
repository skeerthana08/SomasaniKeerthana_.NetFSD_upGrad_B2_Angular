using System;

class StudentResult
{
    // Method using out parameters
    public void CalculateResult(int m1, int m2, int m3, out int total, out double average)
    {
        total = m1 + m2 + m3;
        average = total / 3.0;
    }
}

class Program
{
    static void Main()
    {
        char choice = 'y';

        while (choice == 'y' || choice == 'Y')
        {
            Console.Write("Enter marks 1: ");
            int m1 = int.Parse(Console.ReadLine());

            Console.Write("Enter marks 2: ");
            int m2 = int.Parse(Console.ReadLine());

            Console.Write("Enter marks 3: ");
            int m3 = int.Parse(Console.ReadLine());

            // Validation
            if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
            {
                Console.WriteLine("Invalid marks! Enter between 0 and 100.");
            }
            else
            {
                StudentResult sr = new StudentResult();

                int total;
                double average;

                // Calling method
                sr.CalculateResult(m1, m2, m3, out total, out average);

                Console.WriteLine("\nTotal Marks: " + total);
                Console.WriteLine("Average Marks: " + average);

                if (average >= 40)
                    Console.WriteLine("Result: Pass");
                else
                    Console.WriteLine("Result: Fail");
            }

            Console.Write("\nDo you want to enter another student? (y/n): ");
            string input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                choice = input[0];
            else
                choice = 'n';
        }
    }
}