
using System;
using System.Collections.Generic;

namespace SchoolModel.Models
{
    public class Course : IReportable
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public Teacher ? AssignedTeacher { get; set; }
        public int Capacity { get; }
        
        public List<Student> EnrolledStudents { get; } = new List<Student>();

        public Course(string title, string code, int capacity)
        {
            Title = title;
            Code = code;
            Capacity = capacity;
        }

        public void EnrollStudent(Student student)
        {
            if (EnrolledStudents.Count >= Capacity)
            {
                throw new InvalidOperationException($"Cannot enroll {student.FullName}. Course '{Title}' is at full capacity ({Capacity} students).");

            }

            if (!EnrolledStudents.Contains(student))
            {
                EnrolledStudents.Add(student);
            }
        }

        
        public string GetReportDetails()
        {
           

           string teacherName = AssignedTeacher != null ? AssignedTeacher.FullName : "Unassigned";
            return $"[Course Report] Course: {Title} ({Code}), Teacher: {teacherName}, Enrolled Students: {EnrolledStudents.Count}/{Capacity}";
        
        }
    }
}