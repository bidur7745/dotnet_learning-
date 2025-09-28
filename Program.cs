using learning.Model;
using System;
using System.Text.Json;        // for JsonSerializer
using learning.Model;          // so we can use Student and Subject
using System.IO;               // for File and Path

using System.Text.Json;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loading student from json 
            string filePath = @"E:\IIC stuff\dot net\learning\Data\student.json";
            //Console.WriteLine("Looking for file at: " + filePath);


            // Create a list to hold students
            List<Student> students = new List<Student>();

            // Try to load existing data
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                    Console.WriteLine($"Loaded {students.Count} students from file.");
                }
                else
                {
                    Console.WriteLine("students.json is empty. Starting with an empty list.");
                }
            }
            else
            {
                Console.WriteLine("No students.json found. Starting with an empty list.");
            }



            bool running = true;
            while(running)
            {
                Console.WriteLine(
                "\n===== Student Grade Manager =====\n" +
                "1. Add New Student\n" +
                "2. View All Students\n" +
                "3. Add Subject & Marks\n" +
                "4. Calculate Percentage\n" +
                "5. Exit\n"

                );

                Console.WriteLine("\n\nEnter your Choice:  ");
                int cp = int.Parse(Console.ReadLine());

                switch (cp)
                {
                    case 1:
                        Console.WriteLine(" ===== Enter the student information =====\n");
                        Console.WriteLine(" Enter the student ID");
                         String Id = Console.ReadLine();
                        Console.WriteLine("Enter the name of the student");
                        String Name = Console.ReadLine();
                        
                        Student student = new Student();
                        student.Id = Id;
                        student.Name = Name;
                        students.Add(student);
                        Console.WriteLine("Student added sucessfully!!!!!!");
                        
                        
                        break;
                    case 2:
                        Console.WriteLine("All student are shown here");
                        break;
                    case 3:
                        Console.WriteLine(" New subject will their mark are added here");
                        break;
                    case 4:
                        Console.WriteLine(" Percentage is calculated here");
                        break;
                    case 5:
                        Console.WriteLine("The Programing is closeing .......");
                        running = false;
                        break;
                    default:
                        Console.WriteLine(" wrong choice");
                        break;
                }



            }

        }
    }
}