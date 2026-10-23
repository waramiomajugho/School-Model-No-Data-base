using System;

namespace SchoolModel.Models
{
    public class Teacher : SchoolMembers
    {
        public string Subject { get; set; }

        
        private decimal _salary;
        public decimal Salary 
        {
            get => _salary;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative!");
                }
                _salary = value;
            }
        }

        public Teacher(string id, string firstName, string lastName, DateTime dateOfBirth, string subject, decimal salary)
            : base(id, firstName, lastName, dateOfBirth)
        {
            Subject = subject;
            Salary = salary; 
        }

        
        public override string Describe() => $"[Teacher] {FullName}, Age: {Age}, Subject: {Subject}, Salary: {_salary:C}";
    }
}