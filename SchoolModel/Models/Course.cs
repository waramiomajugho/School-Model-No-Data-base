using System;
using System.Collections.Generic;

namespace SchoolModel.Models
{
    public class Course : IReportable
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public Teacher? AssignedTeacher { get; set; }
        
        
        public int Capacity { get; }
        
        
        private readonly List<Student> _enrolledStudents = new List<Student>();
        
        
        public IReadOnlyCollection<Student> EnrolledStudents => _enrolledStudents.AsReadOnly();

        public Course(string title, string code, int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be greater than zero.");
            Title = title;
            Code = code;
            Capacity = capacity;
        }

        
        public void EnrollStudent(Student student)
        {
            if (_enrolledStudents.Count >= Capacity)
            {
                throw new InvalidOperationException($"Cannot enroll {student.FullName}. Course '{Title}' is at full capacity ({Capacity} students).");
            }

            if (!_enrolledStudents.Contains(student))
            {
                _enrolledStudents.Add(student);
            }
        }

        public string GetReportDetails()
        {
            return $"[Course Report] Course: {Title} ({Code}), Seats: {_enrolledStudents.Count}/{Capacity}";
        }
    }
}