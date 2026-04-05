using System;
using System.Collections.Generic;

namespace SRP_StudentReport
{
    // 1. Student Class (Only holds data)
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
    }

    // 2. StudentRepository (Manages data)
    public class StudentRepository
    {
        public List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ravi", Marks = 85 },
                new Student { StudentId = 2, StudentName = "Priya", Marks = 92 },
                new Student { StudentId = 3, StudentName = "Amit", Marks = 76 }
            };
        }
    }

    // 3. ReportGenerator (Generates report)
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("\n=== Student Report ===\n");

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Grade: {CalculateGrade(student.Marks)}");
                Console.WriteLine("---------------------------");
            }
        }

        private string CalculateGrade(int marks)
        {
            if (marks >= 90) return "A";
            else if (marks >= 75) return "B";
            else return "C";
        }
    }

    // 4. Main Program (Execution starts here)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SRP Student Report System ===");

            StudentRepository repository = new StudentRepository();
            ReportGenerator reportGenerator = new ReportGenerator();

            // Get student data
            List<Student> students = repository.GetStudents();

            // Generate report
            reportGenerator.GenerateReport(students);

            Console.WriteLine("\nProcess Completed.");
        }
    }
}