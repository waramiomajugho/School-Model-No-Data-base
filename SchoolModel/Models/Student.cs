using System;

namespace SchoolModel.Models
{
    
    public class Student : SchoolMembers, IReportable
    {
        public string EnrolmentNumber { get; set; }
        public int YearGroup { get; set; }

        public Student(string id, string firstName, string lastName, DateTime dob, string enrolmentNumber, int yearGroup)
            : base(id, firstName, lastName, dob)
        {
            EnrolmentNumber = enrolmentNumber;
            YearGroup = yearGroup;
        }

        public override string Describe()
        {

            string schoolPhase = YearGroup switch
            {
                >= 7 and <= 9 => "Junior Phase",
                10 or 11 => "GCSE Years",
                12 or 13 => "Sixth Form",
                _ => "General Student"
            };


            return $"[Student] {FullName}, Age: {Age}, Year Group: {YearGroup}, Enrolment: {EnrolmentNumber}";
        }

        
        public string GetReportDetails()
        {
            return $"[Student Report] ID: {Id}, Name: {FullName}, Enrolment: {EnrolmentNumber}, Year Group: {YearGroup}";
        }
    }
}