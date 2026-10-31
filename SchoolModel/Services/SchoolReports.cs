using System;
using System.Linq;
using SchoolModel.Models;

namespace SchoolModel
{
    public class SchoolReports
    {
        private readonly Repository<Student> _studentRepo;
        private readonly Repository<Teacher> _teacherRepo;
        private readonly Repository<Course> _courseRepo;
        private readonly Repository<Department> _departmentRepo;

        public SchoolReports(
            Repository<Student> studentRepo, 
            Repository<Teacher> teacherRepo, 
            Repository<Course> courseRepo, 
            Repository<Department> departmentRepo)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
            _courseRepo = courseRepo;
            _departmentRepo = departmentRepo;
        }

        
        public void PrintStudentsByYearGroup(int yearGroup)
        {
            var students = _studentRepo.GetAll()
                .Where(s => s.YearGroup == yearGroup)
                .OrderBy(s => s.LastName);

            Console.WriteLine($"--- Year {yearGroup} Students (Sorted by Surname) ---");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.LastName}, {s.FirstName} (Enrolment: {s.EnrolmentNumber})");
            }
        }

        
        public void PrintTeachersGroupedByDepartment()
        {
            var teachersByDept = _teacherRepo.GetAll()
                .GroupBy(t => t.Subject); 

            Console.WriteLine("\n--- Teachers Grouped by Department/Subject ---");
            foreach (var group in teachersByDept)
            {
                Console.WriteLine($"Department: {group.Key} (Count: {group.Count()})");
                foreach (var t in group)
                {
                    Console.WriteLine($"  - {t.FirstName} {t.LastName}");
                }
            }
        }

        
        public void PrintTop3CoursesByEnrolment()
        {
            var topCourses = _courseRepo.GetAll()
                .OrderByDescending(c => c.EnrolledStudents.Count)
                .Take(3);

            Console.WriteLine("\n--- Top 3 Courses by Enrolments ---");
            foreach (var c in topCourses)
            {
                Console.WriteLine($"Course: {c.Title} ({c.Code}) - Enrolled: {c.EnrolledStudents.Count}/{c.Capacity}");
            }
        }

        
        public void PrintAverageAgePerYearGroup()
        {
            var avgAgeGroup = _studentRepo.GetAll()
                .GroupBy(s => s.YearGroup)
                .Select(g => new 
                {
                    YearGroup = g.Key,
                    AverageAge = g.Average(s => s.Age)
                });

            Console.WriteLine("\n--- Average Age of Students per Year Group ---");
            foreach (var group in avgAgeGroup)
            {
                Console.WriteLine($"Year {group.YearGroup}: {group.AverageAge:F1} years old");
            }
        }

        
        public void PrintCoursesWithoutTeacher()
        {
            var unassignedCourses = _courseRepo.GetAll()
                .Where(c => c.AssignedTeacher == null);

            Console.WriteLine("\n--- Courses with No Assigned Teacher ---");
            foreach (var c in unassignedCourses)
            {
                Console.WriteLine($"Course: {c.Title} ({c.Code})");
            }
        }

        
        public void PrintTotalSalaryCostPerDepartment()
        {
            var salaryPerDept = _teacherRepo.GetAll()
                .GroupBy(t => t.Subject)
                .Select(g => new 
                {
                    Department = g.Key,
                    TotalSalary = g.Sum(t => t.Salary)
                });

            Console.WriteLine("\n--- Total Salary Cost per Department ---");
            foreach (var item in salaryPerDept)
            {
                Console.WriteLine($"Department: {item.Department} - Total Salary: ${item.TotalSalary:N2}");
            }
        }
    }
}