using System;

namespace SchoolModel.Models
{
    public class Principal : SchoolMembers
    {
        public string OfficeNumber { get; set; }
        public DateTime StartDate { get; set; }

        public Principal(string id, string firstName, string lastName, DateTime dateOfBirth, string officeNumber, DateTime startDate)
            : base(id, firstName, lastName, dateOfBirth)
        {
            OfficeNumber = officeNumber;
            StartDate = startDate;
        }

        
        public override string Describe() => $"[Principal] {FullName}, Age: {Age}, Office: {OfficeNumber}, Start Date: {StartDate:yyyy-MM-dd}";
    }
}