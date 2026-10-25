using System;

namespace SchoolModel.Models
{
    public class Teacher : SchoolMembers, IReportable
    {
        
        private decimal _salary;

        public string Subject { get; set; }

        
        public decimal Salary 
        {
            get => _salary;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Salary cannot be negative.");
                }
                _salary = value;
            }
        }

        public Teacher(string id, string firstName, string lastName, DateTime dob, string subject, decimal salary)
            : base(id, firstName, lastName, dob)
        {
            Subject = subject;
            Salary = salary; 
        }

        public override string Describe() => $"[Teacher] {FullName}, Subject: {Subject}, Salary: ${Salary:N2}";
        public string GetReportDetails() => $"[Teacher Report] ID: {Id}, Name: {FullName}, Salary: ${Salary:N2}";
    }
}