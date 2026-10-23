using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolModel.Models
{
    public class School
    {
        
        public List<SchoolMembers> People { get; set; } = new List<SchoolMembers>();
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Course> Courses { get; set; } = new List<Course>();

        
        public void EnrolStudentToCourse(string studentId, string courseCode)
        {
            var student = People.OfType<Student>().FirstOrDefault(s => s.Id == studentId);
            var course = Courses.FirstOrDefault(c => c.Code == courseCode);

            if (student == null)
            {
                throw new ArgumentException($"Student with ID {studentId} not found.");
            }
            if (course == null)
            {
                throw new ArgumentException($"Course with code {courseCode} not found.");
            }

            course.EnrollStudent(student);
            Console.WriteLine($"Successfully enrolled {student.FullName} into {course.Title}.");
        }

        
        public void AssignTeacherToCourse(string teacherId, string courseCode)
        {
            var teacher = People.OfType<Teacher>().FirstOrDefault(t => t.Id == teacherId);
            var course = Courses.FirstOrDefault(c => c.Code == courseCode);

            if (teacher == null)
            {
                throw new ArgumentException($"Teacher with ID {teacherId} not found.");
            }
            if (course == null)
            {
                throw new ArgumentException($"Course with code {courseCode} not found.");
            }

            course.AssignedTeacher = teacher;
            Console.WriteLine($"Assigned {teacher.FullName} to teach {course.Title}.");
        }

        
        public void TransferTeacher(string teacherId, string targetDepartmentName)
        {
            
            var teacher = People.OfType<Teacher>().FirstOrDefault(t => t.Id == teacherId);
            if (teacher == null)
            {
                throw new ArgumentException($"Teacher with ID {teacherId} not found.");
            }

            
            var targetDepartment = Departments.FirstOrDefault(d => d.Name.Equals(targetDepartmentName, StringComparison.OrdinalIgnoreCase));
            if (targetDepartment == null)
            {
                throw new ArgumentException($"Department '{targetDepartmentName}' not found.");
            }

            
            foreach (var dept in Departments)
            {
                if (dept.Teachers.Contains(teacher))
                {
                    dept.Teachers.Remove(teacher);
                }
            }

            
            targetDepartment.AddTeacher(teacher);
            Console.WriteLine($"Successfully transferred {teacher.FullName} to the {targetDepartment.Name} department.");
        }
    }
}