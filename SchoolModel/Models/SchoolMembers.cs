using System;

namespace SchoolModel.Models
{
    public abstract class SchoolMembers
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        private DateTime _dob;
        public DateTime Dob 
        {
            get => _dob;
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Date of birth cannot be in the future.");
                }
                _dob = value;
            }
        }

        public string FullName => $"{FirstName} {LastName}";

        
        public int Age 
        {
            get
            {
                int age = DateTime.Today.Year - Dob.Year;
                if (Dob.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
        }

        protected SchoolMembers(string id, string firstName, string lastName, DateTime dob)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Dob = dob; // Triggers validation setter
        }

        public abstract string Describe();
    }
}