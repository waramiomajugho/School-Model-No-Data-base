using System.Collections.Generic;

namespace SchoolModel.Models
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher HeadTeacher { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public Department(string name, Teacher headTeacher)
        {
            Name = name;
            HeadTeacher = headTeacher;
            Teachers.Add(headTeacher); 
        }

        public void AddTeacher(Teacher teacher)
        {
            if (!Teachers.Contains(teacher))
            {
                Teachers.Add(teacher);
            }
        }
    }
}