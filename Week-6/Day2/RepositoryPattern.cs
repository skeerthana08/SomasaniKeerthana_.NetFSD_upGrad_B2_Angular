using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPatternDemo
{
    // 1. Entity Class
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
    }

    // 2. Repository Interface
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }

    // 3. Repository Implementation
    public class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
            }
        }
    }

    // 4. Service Layer (Business Logic)
    public class StudentService
    {
        private readonly IStudentRepository repository;

        public StudentService(IStudentRepository repo)
        {
            repository = repo;
        }

        public void AddStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.StudentName))
            {
                Console.WriteLine("Invalid student name!");
                return;
            }

            repository.AddStudent(student);
        }

        public void DisplayAllStudents()
        {
            var students = repository.GetAllStudents();

            Console.WriteLine("\n=== Student List ===");
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.StudentId}, Name: {s.StudentName}, Course: {s.Course}");
            }
        }

        public void FindStudent(int id)
        {
            var student = repository.GetStudentById(id);

            if (student != null)
                Console.WriteLine($"Found → ID: {student.StudentId}, Name: {student.StudentName}, Course: {student.Course}");
            else
                Console.WriteLine("Student not found!");
        }

        public void DeleteStudent(int id)
        {
            repository.DeleteStudent(id);
            Console.WriteLine("Student deleted (if existed).");
        }
    }

    // 5. Main Program (Client)
    class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository repo = new StudentRepository();
            StudentService service = new StudentService(repo);

            Console.WriteLine("=== Student Management System ===");

            // Adding students
            service.AddStudent(new Student { StudentId = 1, StudentName = "Ravi", Course = "CSE" });
            service.AddStudent(new Student { StudentId = 2, StudentName = "Priya", Course = "AI" });
            service.AddStudent(new Student { StudentId = 3, StudentName = "Amit", Course = "ECE" });

            // View all students
            service.DisplayAllStudents();

            // Find student by ID
            Console.WriteLine("\nSearching for Student ID 2...");
            service.FindStudent(2);

            // Delete student
            Console.WriteLine("\nDeleting Student ID 1...");
            service.DeleteStudent(1);

            // View updated list
            service.DisplayAllStudents();

            Console.WriteLine("\nProcess Completed.");
        }
    }
}