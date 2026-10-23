using System;
using System.Collections.Generic;
using SchoolModel.Models;

namespace SchoolModel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<SchoolMembers> schoolPeople = new List<SchoolMembers>
            {
                new Student("S001", "Alice", "Smith", new DateTime(2008, 5, 14), "ENR-2026-01", 10),
                new Teacher("T001", "Bob", "Jones", new DateTime(1985, 9, 22), "Mathematics", 55000m),
                new Principal("P001", "Dr. Charles", "Brown", new DateTime(1970, 3, 10), "Office 101", new DateTime(2015, 8, 1))
            };

            Console.WriteLine("=== School Management System: Directory Test ===");
            Console.WriteLine();

            
            foreach (var person in schoolPeople)
            {
                Console.WriteLine(person.Describe());
            }

            Console.WriteLine();
            Console.WriteLine("===============================================");
        }
    }
}
