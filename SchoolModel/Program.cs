using System;
using System.Collections.Generic;
using System.Linq; 
using SchoolModel.Models;

namespace SchoolModel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            School mySchool = new School();

            
            mySchool.People.Add(new Student("S001", "Alice", "Smith", new DateTime(2008, 5, 14), "ENR-2026-01", 10));
            mySchool.People.Add(new Teacher("T001", "Bob", "Jones", new DateTime(1985, 9, 22), "Mathematics", 55000m));
            mySchool.People.Add(new Principal("P001", "Dr. Charles", "Brown", new DateTime(1970, 3, 10), "Office 101", new DateTime(2015, 8, 1)));
            
            var sampleCourse = new Course("Algebra 101", "MTH101", 30);
            mySchool.Courses.Add(sampleCourse);

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       SCHOOL MANAGEMENT SYSTEM         ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. List All People (Polymorphism Describe)");
                Console.WriteLine("2. Print System Reports (IReportable)");
                Console.WriteLine("3. Add New Person (Student, Teacher, Principal)");
                Console.WriteLine("4. Enrol Student in Course");
                Console.WriteLine("5. Exit");
                Console.WriteLine("========================================");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine()!;
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("=== School Management System: Directory Test ===");
                            Console.WriteLine();
                            foreach (var person in mySchool.People)
                            {
                                Console.WriteLine(person.Describe());
                            }
                            Console.WriteLine();
                            Console.WriteLine("===============================================");
                            break;

                        case "2":
                            Console.WriteLine("=== School System Reports (IReportable) ===");
                            Console.WriteLine();
                            
                            List<IReportable> reportables = new List<IReportable>();
                            reportables.AddRange(mySchool.People.OfType<IReportable>()); 
                            reportables.Add(sampleCourse);       

                            foreach (var item in reportables)
                            {
                                Console.WriteLine(item.GetReportDetails());
                            }

                            Console.WriteLine();
                            Console.WriteLine("===============================================");
                            break;

                        case "3":
                            Console.WriteLine("--- Add New Person ---");
                            Console.WriteLine("1. Student");
                            Console.WriteLine("2. Teacher");
                            Console.WriteLine("3. Principal");
                            Console.Write("Select type to add: ");
                            string typeChoice = Console.ReadLine()!;

                            Console.Write("Enter ID: ");
                            string id = Console.ReadLine()!;
                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine()!;
                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine()!;
                            Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
                            DateTime dob = DateTime.Parse(Console.ReadLine()!);

                            if (typeChoice == "1")
                            {
                                Console.Write("Enter Enrolment Number: ");
                                string enrolmentNo = Console.ReadLine()!;
                                Console.Write("Enter Year Group: ");
                                int yearGroup = int.Parse(Console.ReadLine()!);

                                Student newStudent = new Student(id, firstName, lastName, dob, enrolmentNo, yearGroup);
                                mySchool.People.Add(newStudent);
                                Console.WriteLine("Student added successfully!");
                            }
                            else if (typeChoice == "2")
                            {
                                Console.Write("Enter Subject: ");
                                string subject = Console.ReadLine()!;
                                Console.Write("Enter Salary: ");
                                decimal salary = decimal.Parse(Console.ReadLine()!);

                                Teacher newTeacher = new Teacher(id, firstName, lastName, dob, subject, salary);
                                mySchool.People.Add(newTeacher);
                                Console.WriteLine("Teacher added successfully!");
                            }
                            else if (typeChoice == "3")
                            {
                                Console.Write("Enter Office Number: ");
                                string officeNumber = Console.ReadLine()!;
                                Console.Write("Enter Start Date (YYYY-MM-DD): ");
                                DateTime startDate = DateTime.Parse(Console.ReadLine()!);

                                Principal newPrincipal = new Principal(id, firstName, lastName, dob, officeNumber, startDate);
                                mySchool.People.Add(newPrincipal);
                                Console.WriteLine("Principal added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid person type selected.");
                            }
                            break;

                        case "4":
                            Console.WriteLine("--- Enrol Student ---");
                            Console.Write("Enter Student ID: ");
                            string sId = Console.ReadLine()!;
                            Console.Write("Enter Course Code: ");
                            string cCode = Console.ReadLine()!;
                            
                            mySchool.EnrolStudentToCourse(sId, cCode);
                            Console.WriteLine("Student enrolled successfully!");
                            break;

                        case "5":
                            running = false;
                            Console.WriteLine("Exiting program. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please choose between 1 and 5.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[Error]: {ex.Message}");
                    Console.ResetColor();
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}