using System;

namespace SchoolModel.Models

{
    public class Student : SchoolMembers
    {
        public string EnrolmentNumber { get; }
        public int YearGroup { get; set; }

        public Student(string id, string firstName, string lastName, DateTime dateOfBirth, string enrolmentNumber, int yearGroup)
            : base(id, firstName, lastName, dateOfBirth)
        {
            EnrolmentNumber = enrolmentNumber;
            YearGroup = yearGroup;
        }

        public override string Describe() => $"[Student] {FullName}, Age: {Age}, Year Group: {YearGroup}, Enrolment: {EnrolmentNumber}";
    }
}
