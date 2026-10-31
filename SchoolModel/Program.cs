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
            var mySchool = new School();

            var studentRepo = new Repository<Student>();
            var teacherRepo = new Repository<Teacher>();
            var courseRepo = new Repository<Course>();
            var departmentRepo = new Repository<Department>();

            
            var mathematicsTeacher = new Teacher("T001", "Bob", "Jones", new DateTime(1985, 9, 22), "Mathematics", 55000m) { Id = "T001" };
            var scienceTeacher = new Teacher("T002", "Sarah", "Connor", new DateTime(1980, 4, 12), "Physics", 62000m) { Id = "T002" };
            teacherRepo.Add(mathematicsTeacher);
            teacherRepo.Add(scienceTeacher);

            departmentRepo.Add(new Department("Mathematics", mathematicsTeacher)
            {
                Id = "D001",
                Name = "Mathematics",
                HeadTeacher = mathematicsTeacher,
                Teachers = new List<Teacher> { mathematicsTeacher }
            });
            departmentRepo.Add(new Department("Science", scienceTeacher)
            {
                Id = "D002",
                Name = "Science",
                HeadTeacher = scienceTeacher,
                Teachers = new List<Teacher> { scienceTeacher }
            });

            studentRepo.Add(new Student("S001", "Alice", "Smith", new DateTime(2008, 5, 14), "ENR-2026-01", 10) { Id = "S001" });
            studentRepo.Add(new Student("S002", "Charlie", "Brown", new DateTime(2008, 11, 3), "ENR-2026-02", 10) { Id = "S002" });
            studentRepo.Add(new Student("S003", "Diana", "Prince", new DateTime(2007, 2, 19), "ENR-2026-03", 11) { Id = "S003" });

            courseRepo.Add(new Course("Algebra 101", "MTH101", 30)
            {
                Id = "C001",
                Title = "Algebra 101",
                Code = "MTH101"
            });
            courseRepo.Add(new Course("Physics 101", "SCI101", 25)
            {
                Id = "C002",
                Title = "Physics 101",
                Code = "SCI101"
            });

            
            var reports = new SchoolReports(studentRepo, teacherRepo, courseRepo, departmentRepo);

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("       SCHOOL MANAGEMENT SYSTEM         ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. List All People (Polymorphism Describe)");
                Console.WriteLine("2. Print System Reports (LINQ)"); // Updated label
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
                            
                            Console.WriteLine("=== School System Reports (LINQ Queries) ===");
                            Console.WriteLine();

                            reports.PrintStudentsByYearGroup(10);
                            reports.PrintTeachersGroupedByDepartment();
                            reports.PrintTop3CoursesByEnrolment();
                            reports.PrintAverageAgePerYearGroup();
                            reports.PrintCoursesWithoutTeacher();
                            reports.PrintTotalSalaryCostPerDepartment();

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