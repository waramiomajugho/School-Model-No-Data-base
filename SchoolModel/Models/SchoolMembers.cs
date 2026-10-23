using System;


namespace SchoolModel.Models;

    

public abstract class SchoolMembers 
{
    public string Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public int Age 
    {
        get
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    protected SchoolMembers(string id, string firstName, string lastName, DateTime dob) 
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
    }

    public abstract string Describe();
}