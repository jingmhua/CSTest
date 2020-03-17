using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Null.Models
{
    public class MockStudentImpl : IStudent
    {
        private List<Student> _students;
        public MockStudentImpl()
        {
            _students = new List<Student>()
            {
            new Student {id=1, Name = "name1", ClassName = "classname1", Email = "email1" },
            new Student {id=2, Name = "name2", ClassName = "classname2", Email = "email2" },
            new Student {id=3,Name = "name3", ClassName = "classname3", Email = "email3" }};
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(a=>a.id==id);
        }
    }
}
