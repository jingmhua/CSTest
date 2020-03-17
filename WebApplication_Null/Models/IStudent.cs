using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Null.Models
{
   public interface IStudent
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetAllStudents();
    }
}
