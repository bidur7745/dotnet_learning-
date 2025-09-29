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
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    students = JsonSerializer.Deserialize<List<Student>>(json, options) ?? new List<Student>();



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
                        Console.WriteLine($"The details of the student is:\n");
                        Console.WriteLine($"Name:{student.Name} ID: {student.Id}");
                        
                        
                        break;
                    case 2:
                        Console.WriteLine("\n===== All Students =====\n");

                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students available.");
                            break;
                        }

                        foreach (var s in students)
                        {
                            Console.WriteLine($"ID: {s.Id}   Name: {s.Name}");

                            if (s.Subjects.Count == 0)
                            {
                                Console.WriteLine("   (no courses yet)\n");
                            }
                            else
                            {
                                // Table header
                                Console.WriteLine("   -----------------------------------------------------------");
                                Console.WriteLine($"   {"Subject",-25} {"Full Marks",12} {"Obtained Marks",16}");
                                Console.WriteLine("   -----------------------------------------------------------");

                                // Each course
                                foreach (var c in s.Subjects)
                                {
                                    Console.WriteLine($"   {c.Name,-25} {c.FullMarks,12} {c.ObtainedMarks,16}");
                                }

                                Console.WriteLine(); 
                            }
                        }

                        break;
                    case 3:
                        Console.WriteLine(" Enter the Id of the student you want to add courses: ");
                        String InputId = Console.ReadLine();

                        bool found = false;
                        foreach (var s in students)
                        {
                            if (s.Id == InputId)
                            {
                                found = true;
                                Console.WriteLine(" Enter the name of Courses/subject: ");
                                String SubjectName = Console.ReadLine() ;
                                Console.WriteLine(" Enter the full mark of that subject: ");
                                int FullMarks = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the obtained mark in that subject: ");
                                int ObtainedMarks = int.Parse(Console.ReadLine());

                                Subject subject = new Subject();
                                subject.Name = SubjectName;
                                subject.FullMarks = FullMarks;
                                subject.ObtainedMarks = ObtainedMarks;

                                s.Subjects.Add(subject);
                                Console.WriteLine("Subject added successfully!\n");
                                Console.WriteLine($"Updated record for student: {s.Id} - {s.Name}");
                                Console.WriteLine("-----------------------------------------------------------");
                                Console.WriteLine($"{"Subject",-25} {"Full Marks",12} {"Obtained Marks",16}");
                                Console.WriteLine("-----------------------------------------------------------");

                                foreach (var c in s.Subjects)
                                {
                                    Console.WriteLine($"{c.Name,-25} {c.FullMarks,12} {c.ObtainedMarks,16}");
                                }
                                Console.WriteLine(); 

                                break;


                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine($"Student with ID {InputId} is not available");
                        }

                        break;
                    case 4:
                        Console.WriteLine(" Enter the Id of the student you want to calculate percentage: ");
                        String enteredId = Console.ReadLine();


                        bool check = false;
                        foreach (var s in students)
                        {
                            if (s.Id == enteredId)
                            {
                                check = true;

                                if (s.Subjects.Count == 0)
                                {
                                    Console.WriteLine("No subjects to calculate percentage");
                                }
                                else
                                {
                                    int totalFull = 0;
                                    int totalObtained = 0;

                                    foreach (var sub in s.Subjects)
                                    {
                                        totalFull += sub.FullMarks;
                                        totalObtained += sub.ObtainedMarks;
                                    }

                                    double percentage = (double)totalObtained / totalFull * 100;
                                    Console.WriteLine($"Total: {totalObtained}/{totalFull}");
                                    Console.WriteLine($"Percentage: {percentage:F2}%");
                                }
                            }
                        }
                        if (!check)
                        {
                            Console.WriteLine($"The Student with id {enteredId} is not available");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Saving data and closing the program...");

                        // turn the students list into JSON (pretty printed)
                        string jsonToSave = JsonSerializer.Serialize(
                            students,
                            new JsonSerializerOptions { WriteIndented = true }
                        );

                        // overwrite the same file you loaded from
                        File.WriteAllText(filePath, jsonToSave);

                        Console.WriteLine("All changes saved successfully.");
                        running = false;    // exit the loop/program
                        break;
                    default:
                        Console.WriteLine(" wrong choice");
                        break;
                }



            }

        }
    }
}