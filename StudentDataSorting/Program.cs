using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataSorting
{
    internal class Program
    {

        class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
        }

        static void Main(string[] args)
        {
            string filePath = "D:\\Jan5Project\\student2.txt";
            List<Student> students = ReadStudentData("D:\\Jan5Project\\student2.txt");

            if (students.Count == 0)
            {
                Console.WriteLine("No student data found.");
                return;
            }          
            students = students.OrderBy(s => s.Name).ToList();          
            Console.WriteLine("Sorted Student Data:");
            DisplayStudents(students);
            Console.Write("Enter student name to search: ");
            string searchName = Console.ReadLine();
            SearchStudent(students, searchName);
        }
        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        students.Add(new Student { Name = parts[0].Trim(), Class = parts[1].Trim() });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return students;
        }

        static void DisplayStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }
        }

        static void SearchStudent(List<Student> students, string name)
        {
            Student foundStudent = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                Console.WriteLine($"Student found - Name: {foundStudent.Name}, Class: {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            Console.ReadLine();
        }
      }
    }



